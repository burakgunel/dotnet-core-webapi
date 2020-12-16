//using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using myBusiness.Base;
using myConsumerWebApi.Base;
using myCore.RabbitMq;
using myDomain.DTObjects.RequestDTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace myConsumerWebApi.Consumers
{
    public class MessageConsumer : ConsumerBase<SendMessageRequestDTO>, IHostedService
    {
        protected override string RabbitMqQueueName => "myWebApi.MessageQueue";

        public MessageConsumer(
            ICreateCommand<SendMessageRequestDTO> createCommand,
            ConnectionFactory connectionFactory) : base(createCommand, connectionFactory)
        {
            try
            {
                var consumer = new AsyncEventingBasicConsumer(Channel);
                consumer.Received += OnEventReceived;
                Channel.BasicConsume(queue: RabbitMqQueueName, autoAck: false, consumer: consumer);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while consuming message",ex);
            }
        }

        public virtual Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public virtual Task StopAsync(CancellationToken cancellationToken)
        {
            Dispose();
            return Task.CompletedTask;
        }
    }
}
