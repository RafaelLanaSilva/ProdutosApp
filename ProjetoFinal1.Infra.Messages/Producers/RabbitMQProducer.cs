using Newtonsoft.Json;
using ProjetoFinal1.Domain.Contracts.Messages;
using ProjetoFinal1.Domain.Models.Services;
using ProjetoFinal1.Infra.Messages.Settings;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Messages.Producers
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        public void Send(string message)
        {
            //connectiong to RabbitMQ server
            var connectionFactory = new ConnectionFactory
            {
                Uri = new Uri(RabbitMQSettings.Url)
            };

            //recording the message into line
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var queue = connection.CreateModel())
                {
                    //line information
                    queue.QueueDeclare(
                        queue: RabbitMQSettings.Queue, //line's name
                        durable: true, //won't be erased
                        exclusive: false, //allowed to be accessed by other applications
                        autoDelete: false, //won't remove items automatically
                        arguments: null
                        );

                    //recording line's content
                    queue.BasicPublish(
                        routingKey: RabbitMQSettings.Queue,
                        body: Encoding.UTF8.GetBytes(message),
                        exchange: string.Empty,
                        basicProperties: null
                        );
                }
            }
        }

    }

}
