using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace myCore.RabbitMq
{
    public abstract class RabbitMqClientBase : IDisposable
    {
        protected const string VirtualHost = "aoluauiv";
        protected readonly string QueueExchange = "";
        protected readonly string QueueName = "myWebApi.MessageQueue";
        protected const string QueueAndExchangeRoutingKey = "myWebApi.MessageQueue";

        protected IModel Channel { get; private set; }
        private IConnection _rabbitMqconnection;
        private readonly ConnectionFactory _rabbitMqconnectionFactory;

        protected RabbitMqClientBase(ConnectionFactory connectionFactory)
        {
            _rabbitMqconnectionFactory = connectionFactory;
            ConnectToRabbitMq();
        }

        private void ConnectToRabbitMq()
        {
            if (_rabbitMqconnection == null || _rabbitMqconnection.IsOpen == false)
            {
                _rabbitMqconnection = _rabbitMqconnectionFactory.CreateConnection();
            }

            if (Channel == null || Channel.IsOpen == false)
            {
                Channel = _rabbitMqconnection.CreateModel();
                //Channel.ExchangeDeclare(
                //    exchange: QueueExchange,
                //    type: "direct",
                //    durable: true,
                //    autoDelete: false);

                Channel.QueueDeclare(
                    queue: QueueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false);

                //Channel.QueueBind(
                //    queue: QueueName,
                //    exchange: QueueExchange,
                //    routingKey: QueueAndExchangeRoutingKey);
            }
        }

        public void Dispose()
        {
            try
            {
                Channel?.Close();
                Channel?.Dispose();
                Channel = null;

                _rabbitMqconnection?.Close();
                _rabbitMqconnection?.Dispose();
                _rabbitMqconnection = null;
            }
            catch (Exception ex)
            {
                throw new Exception( "Cannot dispose RabbitMQ channel or connection",ex);
            }
        }
    }
}
