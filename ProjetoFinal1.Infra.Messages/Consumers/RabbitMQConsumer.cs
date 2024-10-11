using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ProjetoFinal1.Domain.Models.Services;
using ProjetoFinal1.Infra.Logs.Collections;
using ProjetoFinal1.Infra.Logs.Persistence;
using ProjetoFinal1.Infra.Messages.Helpers;
using ProjetoFinal1.Infra.Messages.Settings;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal1.Infra.Messages.Consumers
{
    public class RabbitMQConsumer : BackgroundService
    {

        #region Attributes

        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly IModel _model;

        #endregion

        #region Constructor method

        public RabbitMQConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory { Uri = new Uri(RabbitMQSettings.Url) };
            _connection = connectionFactory.CreateConnection();

            _model = _connection.CreateModel();
            _model.QueueDeclare(
                queue: RabbitMQSettings.Queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
                );
        }

        #endregion

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            #region Read and process each message in line

            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += (sender, args) =>
            {
                var contentArray = args.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);

                var message = JsonConvert.DeserializeObject<EmailServiceModel>(contentString);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var logMessages = new LogMessages()
                    {
                        Id = Guid.NewGuid(),
                        DateTime = DateTime.Now
                    };
                    try
                    {
                        MailHelper.SendMail(message);

                        logMessages.Status = "SUCESSO";
                        logMessages.Message = $"Falha ao enviar email para: {message.EmailReceiver}";
                    }
                    catch (Exception e)
                    {
                        logMessages.Status = "ERRO";
                        logMessages.Message = $"Falha ao enviar email para: {message.EmailReceiver} -> {e.Message}";
                    }
                    finally
                    {
                        var logMessagePersistence = new LogMessagesPersistence();
                        logMessagePersistence.Insert(logMessages);
                    }
                    //taking out from the line
                    _model.BasicAck(args.DeliveryTag, false);
                }
            };

            _model.BasicConsume(RabbitMQSettings.Queue, false, consumer);
            return Task.CompletedTask;

            #endregion

        }
    }   
}
