using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using MasterServer.Model;
using Cards;
using Cards.Entities;

namespace MasterServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string queue = "transfer";
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                #region exchange declaration
                channel.ExchangeDeclare(exchange: "loginCall", type: "direct");
                channel.ExchangeDeclare(exchange: "loginResponse", type: "direct");
                channel.ExchangeDeclare(exchange: "registerCall", type: "direct");
                channel.ExchangeDeclare(exchange: "registerResponse", type: "direct");
                channel.ExchangeDeclare(exchange: "createGameCall", type: "direct");
                channel.ExchangeDeclare(exchange: "createGameResponse", type: "direct");
                channel.ExchangeDeclare(exchange: "joinGameCall", type: "direct");
                channel.ExchangeDeclare(exchange: "joinGameResponse", type: "direct");
                channel.ExchangeDeclare(exchange: "exitGameCall", type: "direct");
                channel.ExchangeDeclare(exchange: "exitGameResponse", type: "direct");
                channel.ExchangeDeclare(exchange: "gameListCall", type: "direct");
                channel.ExchangeDeclare(exchange: "gameListResponse", type: "direct");
                channel.ExchangeDeclare(exchange: "gameStatusCall", type: "direct");
                channel.ExchangeDeclare(exchange: "gameStatusResponse", type: "direct");
                channel.ExchangeDeclare(exchange: "gameStartCall", type: "direct");
                channel.ExchangeDeclare(exchange: "gameStartResponse", type: "direct");
                #endregion

                #region queue declare and binding
                channel.QueueDeclare(queue: queue,
                                             durable: false,
                                             exclusive: false,
                                            autoDelete: false,
                                             arguments: null);
                
                channel.QueueBind(queue: queue,
                                  exchange: "loginCall",
                                  routingKey: "login");

                channel.QueueBind(queue: queue,
                                  exchange: "registerCall",
                                  routingKey: "register");

                channel.QueueBind(queue: queue,
                                  exchange: "createGameCall",
                                  routingKey: "createGame");

                channel.QueueBind(queue: queue,
                                  exchange: "joinGameCall",
                                  routingKey: "joinGame");
                
                channel.QueueBind(queue: queue,
                                  exchange: "gameListCall",
                                  routingKey: "gameList");

                channel.QueueBind(queue: queue,
                                  exchange: "exitGameCall",
                                  routingKey: "exitGame");

                channel.QueueBind(queue: queue,
                                  exchange: "gameStatusCall",
                                  routingKey: "gameStatus");

                channel.QueueBind(queue: queue,
                                  exchange: "gameStartCall",
                                  routingKey: "gameStart");
                #endregion     

                Console.WriteLine(" [*] UNO MASTER SERVER STARTED");
                Console.WriteLine(" [*] Dejan Randjelovic 15843");
                Console.WriteLine(" [*] Nikola Popovic 15826");
                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    #region attributes
                    Proxy proxy = new Proxy();
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    var response = "";
                    Object o = null;
                    String[] p = message.Split(':');
                    ViewClass pr = new ViewClass();
                    #endregion

                    Console.WriteLine(" [*]");
                    Console.WriteLine(" [*] Message received");
                    Console.WriteLine(" [R] {0}", message);
                    Console.WriteLine(" [*] ");

                    switch (ea.RoutingKey)
                    {
                        case "login":
                            {
                                Player i = proxy.ReturnPlayer(p[1]);
                                bool success = false;
                                if (i == null)
                                    response = "Username is not recognized";
                                else if (!i.password.Equals(p[3]))
                                    response = "You entered wrong password";
                                else
                                {
                                    pr.player = i;
                                    pr.games = proxy.ReturnGames();
                                    success = true;
                                }
                                if (!success)
                                    o = response;
                                else
                                {
                                    response = i.username;
                                    o = pr;
                                }
                                var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
                                channel.BasicPublish(exchange: "loginResponse",
                                                     routingKey: p[p.Length - 1],
                                                     basicProperties: null,
                                                     body: body1);
                                Console.WriteLine(" [S] {0}", response);
                                break;
                            }
                        case "register":
                            {
                                bool succes = proxy.AddPlayer(p[1], p[3]);
                                if (succes)
                                {
                                    response = "Registration success!";
                                }
                                else
                                {
                                    response = "Registration failed, username already taken!";
                                }
                                o = response;

                                var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
                                channel.BasicPublish(exchange: "registerResponse",
                                                     routingKey: p[p.Length - 1],
                                                     basicProperties: null,
                                                     body: body1);
                                Console.WriteLine(" [S] {0}", response);
                                break;
                            }
                        case "createGame":
                            {
                                Game i = proxy.CheckGameName(p[1], p[3], p[5]);
                                if (i == null)
                                    response = "Game with that name already exists";
                                if (response == "")
                                {
                                    response = "Created game: " + i.name;
                                    o = i;
                                }
                                else o = response;

                                var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
                                channel.BasicPublish(exchange: "createGameResponse",
                                                     routingKey: p[p.Length - 1],
                                                     basicProperties: null,
                                                     body: body1);
                                Console.WriteLine(" [S] {0}", response);
                                break; 
                            }
                        case "joinGame":
                            {
                                Game i = proxy.JoinGame(p[1], p[3]);
                                if (i == null)
                                    response = "Failed to join game";
                                if (response == "")
                                {
                                    response = "Joined game: " + i.name;
                                    o = i;
                                }
                                else o = response;

                                var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
                                channel.BasicPublish(exchange: "joinGameResponse",
                                                     routingKey: p[p.Length - 1],
                                                     basicProperties: null,
                                                     body: body1);
                                Console.WriteLine(" [S] {0}", response);
                                break;
                            }
                        case "gameList": 
                            {
                                IList<Game> listofGames = proxy.ReturnGames();

                                o = listofGames;
                                response = "Game list updated";
                                var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
                                channel.BasicPublish(exchange: "gameListResponse",
                                                     routingKey: p[p.Length - 1],
                                                     basicProperties: null,
                                                     body: body1);
                                Console.WriteLine(" [S] {0}", response);
                                break;
                            }
                        case "exitGame":
                            {
                                proxy.ExitGame(p[1], p[3]);

                                pr.games = proxy.ReturnGames();
                                pr.player = proxy.ReturnPlayer(p[3]);
                                response = "Player " + pr.player.username + " left "+ p[1];
                                o = pr;

                                var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
                                channel.BasicPublish(exchange: "exitGameResponse",
                                                     routingKey: p[p.Length - 1],
                                                     basicProperties: null,
                                                     body: body1);
                                Console.WriteLine(" [S] {0}", response);
                                break;
                            }
                        case "gameStatus":
                            {
                                JsonSerializerSettings settings = new JsonSerializerSettings
                                {
                                    TypeNameHandling = TypeNameHandling.Auto

                                };

                                var s1 = JsonConvert.DeserializeObject<GameStatus>(message, settings);

                                #region Player Count Check
                                Game game = proxy.ReturnGame(s1.gameId);
                                bool found;

                                while(game.players.Count != s1.playerCards.Count)
                                {
                                    for(int i=0; i<s1.playerCards.Count; i++)
                                    {
                                        found = false;
                                        for(int j=0; j<game.players.Count; j++)
                                        {
                                            if(!found)
                                            {
                                                if(game.players[j].username.Equals(s1.playerCards[i].Name))
                                                {
                                                    found = true;
                                                }
                                            }
                                        }
                                        if(!found)
                                        {
                                            s1.playerCards.Remove(s1.playerCards[i]);
                                            if (s1.reversed)
                                            {
                                                if (s1.currentPlayerId == s1.playerCards.Count)
                                                {
                                                    s1.currentPlayerId--;
                                                }
                                            }
                                            else
                                            {
                                                if (s1.currentPlayerId == s1.playerCards.Count)
                                                {
                                                    s1.currentPlayerId = 0;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                                #endregion

                                if (s1.currentPlayerId == s1.maxPlayers)
                                {
                                    if(s1.reversed)
                                    {
                                        s1.currentPlayerId--;
                                    }
                                    else
                                    {
                                        s1.currentPlayerId = 0;
                                    }
                                }

                                #region Winner
                                if (s1.playerCards.Count == 1)
                                {
                                    proxy.WinCountInc(s1.playerCards[0].Name);
                                    s1.winner = s1.playerCards[0].Name;
                                }

                                foreach (PlayerCards player in s1.playerCards)
                                {
                                    if (player.Cards.Count == 0)
                                    {
                                        proxy.WinCountInc(player.Name);
                                        s1.winner = player.Name;
                                        break;
                                    }
                                }
                                #endregion

                                var routing = "game" + s1.gameId.ToString();
                                var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(s1, settings));
                                channel.BasicPublish(exchange: "gameStatusResponse",
                                                     routingKey: routing,
                                                     basicProperties: null,
                                                     body: body1);
                                Console.WriteLine(" [S] Game status sent to game: {0}", s1.gameId.ToString());
                                break;
                            }
                        case "gameStart":
                            {
                                JsonSerializerSettings settings = new JsonSerializerSettings
                                {
                                    TypeNameHandling = TypeNameHandling.Auto

                                };

                                int s1 = Int32.Parse(message);

                                Game game = proxy.ReturnGame(s1);
                                
                                var routing = "game" + game.name.ToString();
                                var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(game, settings));
                                channel.BasicPublish(exchange: "gameStartResponse",
                                                     routingKey: routing,
                                                     basicProperties: null,
                                                     body: body1);
                                Console.WriteLine(" [S] Game: " + game.name + " has " + game.currentPlayerCount + "/" + game.maxPlayerCount + " players");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine(" [S] Wrong routing key" + ea.RoutingKey);
                                int id = Int32.Parse(message);
                                break;
                            }
                    }

                    Console.WriteLine(" [*] Press any key to exit...");
                };
                channel.BasicConsume(queue: queue,
                                     autoAck: true,
                                     consumer: consumer);
                
                Console.WriteLine(" [*] Press any key to exit...");
                Console.ReadLine();
            }
        }
    }
}