using Microsoft.Extensions.Logging;
using myCore.RabbitMq;
using myDomain.Base;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace myPublisherBusiness.Base
{
    
    public abstract class PublisherBase<Tin,TOut> : RabbitMqClientBase, IRabbitMqPublisher<Tin, TOut> where TOut : BaseResponseDTO, new()
    {
        protected abstract string ExchangeName { get; }
        protected abstract string RoutingKeyName { get; }
        protected abstract string AppId { get; }

        protected PublisherBase(ConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public virtual TOut Publish(Tin message)
        {
            try
            {
                TOut response = new TOut();
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                var properties = Channel.CreateBasicProperties();
                properties.AppId = AppId;
                properties.ContentType = "application/json";
                properties.DeliveryMode = 1; // Doesn't persist to disk
                properties.Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                Channel.BasicPublish(exchange: ExchangeName, routingKey: RoutingKeyName, body: body, basicProperties: properties);
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while publishing", ex);
            }
        }
    }
}
