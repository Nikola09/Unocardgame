using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Util;
using Newtonsoft.Json;

namespace UnoTest
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {

                string username = txtUsernameReg.Text;
                string password = txtPassReg.Text;
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "registerResponse", type: "direct");
                    
                    var queueName = channel.QueueDeclare().QueueName;

                    channel.QueueBind(queue: queueName,
                                      exchange: "registerResponse",
                                      routingKey: queueName);

                    Console.WriteLine(" [*] Waiting for logs.");

                    var consumer = new EventingBasicConsumer(channel);
                    bool primio = false;
                    var messageR = "";
                    consumer.Received += (model, ea) =>
                    {
                        var body1 = ea.Body;
                        var message1 = Encoding.UTF8.GetString(body1);
                        messageR = message1;
                        primio = true;
                    };

                    channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);
                    var message = "username:" + username + ": password:" + password + ": routingKey:" + queueName;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "registerCall",
                                         routingKey: "register",
                                         basicProperties: null,
                                         body: body);
                    while (!primio) ;
                    if (messageR.Length < 30)
                    {
                        MessageBox.Show(messageR.ToString());
                        LogInForm log = new LogInForm();
                        this.Hide();
                        this.Close();
                        log.ShowDialog();

                    }
                    else
                    {
                         MessageBox.Show(messageR.ToString());
                    }
                };   
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void BtnBackLog_Click(object sender, EventArgs e)
        {
            LogInForm l = new LogInForm();
            this.Hide();
            l.ShowDialog();
            this.Close();
        }
    }
}
