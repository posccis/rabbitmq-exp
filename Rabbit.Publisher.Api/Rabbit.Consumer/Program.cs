// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text.Json.Serialization;
using Rabbit.Models.Entities;
using System.Text.Json;


var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "vito",
    Password = "123456",
};
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var message_deco = JsonSerializer.Deserialize<RabbitMensagem>(message);
    Console.WriteLine($"-- Titulo: {message_deco.Titulo}\n-- Texto: {message_deco.Texto}\n-- Id: {message_deco.Id}");
};
channel.BasicConsume(queue: "RabbitMensagesQueue",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
