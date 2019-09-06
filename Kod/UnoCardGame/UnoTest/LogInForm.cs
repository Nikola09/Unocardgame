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
using Cards;

namespace UnoTest
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private void LlblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm reg = new RegisterForm();
            this.Hide();
            reg.ShowDialog();
            this.Close();
        }

        private void BtnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtLogUsername.Text;
                string password = txtPassLog.Text;

                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "loginResponse", type: "direct");
                    
                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queueName,
                                      exchange: "loginResponse",
                                      routingKey: queueName);

                    Console.WriteLine(" [*] Waiting for logs.");

                    var consumer = new EventingBasicConsumer(channel);
                    bool primio = false;
                    var messageR ="" ;
                    consumer.Received += (model, ea) =>
                    {
                        messageR = Encoding.UTF8.GetString(ea.Body);
                        primio = true;
                    };

                    channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);
                    var message = "username:" + username + ": password:" + password + ": routingKey:" + queueName;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "loginCall",
                                         routingKey: "login",
                                         basicProperties: null,
                                         body: body);
                while (!primio);
                if (messageR.Length < 30)
                {
                    MessageBox.Show(messageR);
                }
                else
                {
                    var s1 = JsonConvert.DeserializeObject<ViewClass>(messageR);
                    this.Hide();
                    LoggedInScreen f = new LoggedInScreen(s1);
                    f.ShowDialog();
                    this.Close();
                }
            };
                }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void BtnLogIn_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
    }
}
