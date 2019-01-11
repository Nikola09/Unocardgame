using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using MasterServer;
using MasterServer.Entities;
using MasterServer.Model;

namespace MasterServer
{
    class Program
    {
        static void Main(string[] args)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "logs1", type: "direct");
                channel.ExchangeDeclare(exchange: "logs2", type: "direct");

                //var queueName = channel.QueueDeclare().QueueName;
                channel.QueueDeclare(queue: "transfer",
                                             durable: false,
                                             exclusive: false,
                                            autoDelete: false,
                                             arguments: null);
                channel.QueueBind(queue: "transfer",
                                  exchange: "logs1",
                                  routingKey: "transfer");
                channel.QueueBind(queue: "transfer",
                                  exchange: "logs1",
                                  routingKey: "transferZ");

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    MasterServer.Model.IModel klasa = new Modell ();
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] {0}", message);
                    Console.WriteLine(" [x] {0}", ea.RoutingKey);
                    if (ea.RoutingKey == "transfer")
                    {

                        String[] p = message.Split(':');
                        var message1 = "";
                        Object o = null;
                        ViewClass pr = new ViewClass();
                        Player i = klasa.returnPlayer(p[1]);
                        if (i == null)
                            message1 = "You entered wrong username";
                        else if (i.password != p[3])
                            message1 = "You entered wrong password";
                        else
                        {
                            pr.player = i;
                            pr.games = klasa.returnGames();
                        }
                        if (pr == null)
                            o = message1;
                        else o = pr;
                        //JsonSerializerSettings settings = new JsonSerializerSettings();
                        //settings.TypeNameHandling = TypeNameHandling.Auto;
                        var body1 = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
                        channel.BasicPublish(exchange: "logs2",
                                             routingKey: p[p.Length - 1],
                                             basicProperties: null,
                                             body: body1);
                        Console.WriteLine(" [x] Sent {0}", message1);
                    }
                    else
                    {
                        Console.WriteLine("Wrong routing key" + ea.RoutingKey);
                        int id = Int32.Parse(message);
                        //klasa.
                    }
                };
                channel.BasicConsume(queue: "transfer",
                                     autoAck: true,
                                     consumer: consumer);



                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
