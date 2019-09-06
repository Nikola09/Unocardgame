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
using Cards.Entities;

namespace UnoTest
{
    public partial class CreateNewGameForm : Form
    {
        private ViewClass context;

        public CreateNewGameForm(ViewClass v)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.context = v;
            this.Text = this.context.player.username;
            this.dUpDown.Text = this.dUpDown.Items[0].ToString();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoggedInScreen f = new LoggedInScreen(this.context);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void BtnCreateNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;

                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "createGameResponse", type: "direct");




                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queueName,
                                      exchange: "createGameResponse",
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
                    var message = "gamename:" + name + ": maxplayercount:" + dUpDown.Text + ": player:" + this.context.player.username + ": routingKey:" + queueName;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "createGameCall",
                                         routingKey: "createGame",
                                         basicProperties: null,
                                         body: body);
                    while (!primio) ;
                    if (messageR.Length == 36)
                    {
                        MessageBox.Show(messageR.ToString());
                    }
                    else
                    {
                        var s1 = JsonConvert.DeserializeObject<Game>(messageR);
                        this.context.games.Add(s1);
                        this.Hide();
                        GameForm l = new GameForm(s1, this.context);
                        l.ShowDialog();
                        this.Close();
                    }
                };

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }
        }
    }

