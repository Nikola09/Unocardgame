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
using CardsModel;
using Cards.Entities;
using Cards;

namespace UnoTest
{
    public partial class GameForm : Form
    {
        private IList<PictureBox> cardBoxes;
        private GameLogic gameLogic;
        private Game g;
        private ViewClass context;
        private bool bought;
        private bool activeForm;
        private bool isListening;
        private bool gameStarted;
        private IList<PlayerCards> players;
        private bool finish;
        
        public GameForm(Game game, ViewClass v)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.context = v;
            this.g = game;
            this.cardBoxes = new List<PictureBox>();
            this.lblGameName.Text = g.name;
            this.Text = this.context.player.username;
            this.btnEndTurn.Hide();
            this.lblOnTurn.Hide();

            this.bought = false;
            this.finish = false;
            this.gameStarted = true;
            this.activeForm = true;
            this.isListening = true;

            gameLogic = new GameLogic();
            gameLogic.SetPlayers(new List<Player>(g.players));
            gameLogic.SetGameId(g.id); 
            gameLogic.SetMyName(v.player.username);

            foreach (Player player in this.g.players)
            {
                ListViewItem item = new ListViewItem(player.username);
                item.SubItems.Add("");

                this.listPlayers.Items.Add(item);
            }
        }

        private void RefreshCards()
        {
            cardBoxes.Clear();
            int index = 0;
            foreach(var card in gameLogic.GetHand())
            {
                var cardBox = new PictureBox
                {
                    Name = "card" + index++,
                    SizeMode = PictureBoxSizeMode.StretchImage
                };
                if (index < 16)
                {
                    cardBox.Location = new Point(10 + 90 * (index - 1), 0);
                }
                else if(index < 31)
                {
                    cardBox.Location = new Point(10 + 90 * (index - 16), 125);
                }
                else
                {
                    cardBox.Location = new Point(10 + 90 * (index - 31), 250);
                }
                cardBox.Width = 80;
                cardBox.Height = 120;
                cardBox.Tag = card;
                cardBox.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                cardBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);

                cardBox.Image= Bitmap.FromFile(card.GetPath());

                panelMyCards.Controls.Add(cardBox);
                cardBoxes.Add(cardBox);
                cardBox.MouseClick += CardBox_MouseClick;
            }

            pbxField.Image = Bitmap.FromFile(gameLogic.GetTopCardField().GetPath());
        }

        void CardBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameLogic.IsMyTurn() && !this.finish)
            {
                var cardBox = sender as PictureBox;

                Card c = (Card)cardBox.Tag;

                Card f = gameLogic.GetTopCardField();
                if (gameLogic.CanthrowCard(c))
                {
                    bought = false;
                    gameLogic.AddTopCardToDeck(f);
                    gameLogic.CurrentPlayerThrowsCard(c);
                    panelMyCards.Controls.Clear();
                    RefreshCards();
                    EndMyTurn();
                }
            }
        }
        
        private void BtnExit_Click(object sender, EventArgs e)
        {
            if(!gameLogic.IsMyTurn() || this.finish == true)
            {
                string name = lblGameName.Text;

                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "exitGameResponse", type: "direct");

                    var queueName = channel.QueueDeclare().QueueName;

                    channel.QueueBind(queue: queueName,
                                      exchange: "exitGameResponse",
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

                    var message = "gamename:" + name + ":username:" + this.context.player.username + ": routingKey:" + queueName;
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "exitGameCall",
                                         routingKey: "exitGame",
                                         basicProperties: null,
                                         body: body);

                   
                    GameStartListening();
                    
                    while (!primio) ;

                    gameStarted = false;
                    isListening = false;
                    activeForm = false;
                    
                    this.context = JsonConvert.DeserializeObject<ViewClass>(messageR);
                    this.Hide();
                    activeForm = false;
                    LoggedInScreen l = new LoggedInScreen(this.context);
                    l.ShowDialog();
                    isListening = false;
                    this.Close();
                };
            }
        }

        private void PbxDeck_MouseClick(object sender, MouseEventArgs e)
        {
            if (!bought && gameLogic.ReturnGameStatus() != null && gameLogic.IsMyTurn() && !this.finish)
            {
                gameLogic.CurrentPlayerBuy(1);
                panelMyCards.Controls.Clear();
                RefreshCards();
                bought = true;
            }
        }

        private void BtnEndTurn_Click(object sender, EventArgs e)
        {
            if (bought && gameLogic.IsMyTurn())
            {
                bought = false;
                panelMyCards.Controls.Clear();
                RefreshCards();
                gameLogic.NextPlayer();
                EndMyTurn();
            }
        }
        
        public void EndMyTurn()
        {
            try
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    var queueName = channel.QueueDeclare().QueueName;

                    var message = gameLogic.SendStatus();
                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                    channel.BasicPublish(exchange: "gameStatusCall",
                                         routingKey: "gameStatus",
                                         basicProperties: null,
                                         body: body);
                }
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            GameStartListening();
            StartListening();
        }

        #region Delegates
        delegate void AddPlayerToListCallback(ListViewItem player);

        public void AddPlayerToList(ListViewItem player)
        {
            if (this.listPlayers.InvokeRequired)
            {
                AddPlayerToListCallback d = new AddPlayerToListCallback(AddPlayerToList);
                this.Invoke(d, new object[] { player });
            }
            else
            {
                if (!this.listPlayers.Items.Contains(player))
                {
                    this.listPlayers.Items.Add(player);
                }
            }
        }

        delegate void ClearListCallback();

        public void ClearList()
        {
            if (this.listPlayers.InvokeRequired)
            {
                ClearListCallback d = new ClearListCallback(ClearList);
                this.Invoke(d);
            }
            else
            {
                this.listPlayers.Items.Clear();
            }
        }

        delegate void SetOnTurnLabelCallback(String onTurn);

        public void SetOnTurnLabel(String onTurn)
        {
            if (this.txtOnTurn.InvokeRequired)
            {
                SetOnTurnLabelCallback d = new SetOnTurnLabelCallback(SetOnTurnLabel);
                this.Invoke(d, new object[] { onTurn });
            }
            else
            {
                this.txtOnTurn.Text = onTurn;
            }
        }

        delegate void SetWinnerLabelCallback();

        public void SetWinnerLabel()
        {
            if (this.txtOnTurn.InvokeRequired)
            {
                SetWinnerLabelCallback d = new SetWinnerLabelCallback(SetWinnerLabel);
                this.Invoke(d);
            }
            else
            {
                this.lblOnTurn.Text = "Winner: ";
                this.lblOnTurn.ForeColor = Color.Green;
            }
        }

        delegate void SetOnStatusCallback();

        public void SetOnStatus()
        {
            if (this.txtStatus.InvokeRequired)
            {
                SetOnStatusCallback d = new SetOnStatusCallback(SetOnStatus);
                this.Invoke(d);
            }
            else
            {
                if (!this.finish)
                {
                    this.txtStatus.Text = "Active";
                    this.txtStatus.ForeColor = Color.Green;
                }
                else
                {
                    this.txtStatus.Text = "Finished";
                    this.txtStatus.ForeColor = Color.Red;
                }
            }
        }

        delegate void MakeVisibleCallback();

        public void MakeVisible()
        {
            if (this.lblOnTurn.InvokeRequired)
            {
                MakeVisibleCallback d = new MakeVisibleCallback(MakeVisible);
                this.Invoke(d);
            }
            else
            {
                this.lblOnTurn.Show();
                this.btnEndTurn.Show();
            }
        }

        delegate void HideEndTUrnButtonCallback();

        public void HideEndTurnButton()
        {
            if (this.btnEndTurn.InvokeRequired)
            {
                HideEndTUrnButtonCallback d = new HideEndTUrnButtonCallback(HideEndTurnButton);
                this.Invoke(d);
            }
            else
            {
                this.btnEndTurn.Hide();
            }
        }
        #endregion

        private void StartListening()
        {
            Task.Run(() =>
            {
                try
                {
                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.ExchangeDeclare(exchange: "gameStatusResponse", type: "direct");

                        var queueName = channel.QueueDeclare().QueueName;
                        var routing = "game" + g.id.ToString();
                        channel.QueueBind(queue: queueName,
                                          exchange: "gameStatusResponse",
                                          routingKey: routing);

                        var consumer = new EventingBasicConsumer(channel);
                        var messageR = "";
                        JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto};
                        consumer.Received += (model, ea) =>
                        {
                            MakeVisible();
                            var body1 = ea.Body;
                            var message1 = Encoding.UTF8.GetString(body1);
                            messageR = message1;
                            var gs = JsonConvert.DeserializeObject<GameStatus>(messageR,settings);
                            gameLogic.GetStatus(gs);

                            this.players = gs.playerCards;

                            ClearList();
                            this.listPlayers.Items.Clear();
                            foreach (PlayerCards p in players)
                            {
                                ListViewItem item = new ListViewItem(p.Name);
                                item.SubItems.Add(p.Cards.Count.ToString());

                                AddPlayerToList(item);
                            }

                            if (!gameLogic.ReturnWinner().Equals(""))
                            {
                                SetWinnerLabel();
                                SetOnTurnLabel(gameLogic.ReturnWinner());
                                HideEndTurnButton();
                                this.finish = true;
                            }
                            else
                            {
                                SetOnTurnLabel(gameLogic.GetOnTurn());

                                this.Invoke(new Action(() => RefreshCards()));
                            }

                            SetOnStatus();
                        };

                        channel.BasicConsume(queue: queueName,
                                             autoAck: true,
                                             consumer: consumer);

                        if (g.currentPlayerCount == g.maxPlayerCount)
                        {
                            var message = gameLogic.CreateStatus();
                            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message, settings));
                            channel.BasicPublish(exchange: "gameStatusCall",
                                                 routingKey: "gameStatus",
                                                 basicProperties: null,
                                                 body: body);
                        }

                        while (isListening)
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
            });
        }

        private void GameStartListening()
        {
            Task.Run(() =>
            {
                try
                {
                    var factory = new ConnectionFactory() { HostName = "localhost" };
                    using (var connection = factory.CreateConnection())
                    using (var channel = connection.CreateModel())
                    {
                        channel.ExchangeDeclare(exchange: "gameStartResponse", type: "direct");

                        var queueName = channel.QueueDeclare().QueueName;
                        var routing = "game" + g.name.ToString();
                        channel.QueueBind(queue: queueName,
                                          exchange: "gameStartResponse",
                                          routingKey: routing);

                        var consumer = new EventingBasicConsumer(channel);
                        var messageR = "";
                        JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                        consumer.Received += (model, ea) =>
                        {
                            var body1 = ea.Body;
                            var message1 = Encoding.UTF8.GetString(body1);
                            messageR = message1;
                            var game = JsonConvert.DeserializeObject<Game>(messageR, settings);
                            this.g = game;
                            ClearList();
                            foreach (Player player in this.g.players)
                            {
                                ListViewItem item = new ListViewItem(player.username);
                                item.SubItems.Add("");

                                AddPlayerToList(item);
                            }
                        };

                        channel.BasicConsume(queue: queueName,
                                             autoAck: true,
                                             consumer: consumer);
                        
                        if (g.currentPlayerCount > 1 && gameLogic.ReturnGameStatus() == null)
                        {
                            var message = g.id;
                            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message, settings));
                            channel.BasicPublish(exchange: "gameStartCall",
                                                 routingKey: "gameStart",
                                                 basicProperties: null,
                                                 body: body);
                        }

                        while (gameStarted)
                        {
                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                }
                catch (Exception ec)
                {
                    MessageBox.Show(ec.Message);
                }
            });
        }
    }
}