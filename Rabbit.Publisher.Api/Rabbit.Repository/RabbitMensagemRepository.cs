using Rabbit.Models.Entities;
using Rabbit.Repository.Interfaces;
using RabbitMQ.Client;
using System.Text;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rabbit.Repository
{
    public class RabbitMensagemRepository : IRabbitMensagemRepository
    {
        public void SendMnesagem(RabbitMensagem mensagem)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "vito",
                Password = "123456",
            };
            using (var connection = factory.CreateConnection()) 
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "RabbitMensagesQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonSerializer.Serialize(mensagem);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "RabbitMensagesQueue",
                                     basicProperties: null,
                                     body: body);
            }



        }
    }
}
