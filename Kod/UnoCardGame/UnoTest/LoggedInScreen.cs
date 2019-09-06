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
    public partial class LoggedInScreen : Form
    {
        private ViewClass context;

        public LoggedInScreen(ViewClass v)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            context = v;
            this.Text = context.player.username;

            lblUsername.Text = v.player.username;
            lblWinCount.Text = v.player.winCount.ToString();

            this.RefreshList();
        }

        private void RefreshList()
        {
            try
            {
                string username = lblUsername.Text;
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "gameListResponse", type: "direct");
                    
                    var queueName = channel.QueueDeclare().QueueName;
                    channel.QueueBind(queue: queueName,
                                      exchange: "gameListResponse",
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

                    var message = "username:" + username + ": routingKey:" + queueName;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "gameListCall",
                                         routingKey: "gameList",
                                         basicProperties: null,
                                         body: body);
                    while (!primio) ;

                    context.games = JsonConvert.DeserializeObject<List<Game>>(messageR);
                    this.listView1.Items.Clear();
                    foreach (Game f in context.games)
                    {
                        if (f.status == 0)
                        {
                            ListViewItem item = new ListViewItem(f.name);
                            item.SubItems.Add(f.currentPlayerCount.ToString());
                            item.SubItems.Add(f.maxPlayerCount.ToString());
                            this.listView1.Items.Add(item);
                        }
                    }
                    this.listView1.Refresh();
                };

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void BtnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = lblUsername.Text;
                string name = listView1.SelectedItems[0].Text ;
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "joinGameResponse", type: "direct");
                    
                    var queueName = channel.QueueDeclare().QueueName;
                    
                    channel.QueueBind(queue: queueName,
                                      exchange: "joinGameResponse",
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
                    var message = "username:" + username + ": gamename:" + name + ": routingKey:" + queueName;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "joinGameCall",
                                         routingKey: "joinGame",
                                         basicProperties: null,
                                         body: body);
                    while (!primio) ;
                    if (messageR.Length < 30)
                    {
                        MessageBox.Show(messageR.ToString());

                    }
                    else
                    {
                        var s1 = JsonConvert.DeserializeObject<Game>(messageR);
                        
                        if (s1.currentPlayerCount == s1.maxPlayerCount)
                        {
                            this.listView1.Items.Clear();
                            foreach (Game game in context.games)
                            {
                                if (!game.name.Equals(s1.name))
                                {
                                    ListViewItem item = new ListViewItem(game.name);
                                    item.SubItems.Add(game.currentPlayerCount.ToString());
                                    item.SubItems.Add(game.maxPlayerCount.ToString());
                                    this.listView1.Items.Add(item);
                                }
                            }
                            this.listView1.Refresh();
                        }

                        this.Hide();
                        GameForm l = new GameForm(s1, context);
                        l.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch (Exception ec)
            {
                ec.Source = "No game selected!";
                MessageBox.Show(ec.Source.ToString());
            }
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            LogInForm l = new LogInForm(); 
            this.Hide();
            l.ShowDialog();
            this.Close();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateNewGameForm c = new CreateNewGameForm(context);
            this.Hide();
            c.ShowDialog();
            this.Close();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshList();
        }
    }
}
