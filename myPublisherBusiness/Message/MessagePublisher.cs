using Microsoft.Extensions.Logging;
using myCore.RabbitMq;
using myDomain.DTObjects.RequestDTO;
using myDomain.DTObjects.ResponseDTO;
using myPublisherBusiness.Base;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace myPublisherBusiness.Message
{
    
    public class MessagePublisher : PublisherBase<SendMessageRequestDTO,SendMessageResponseDTO>
    {
        public MessagePublisher(
            ConnectionFactory connectionFactory) :
            base(connectionFactory)
        {
        }

        protected override string ExchangeName => "";
        protected override string RoutingKeyName => "myWebApi.MessageQueue";
        protected override string AppId => "aoluauiv";
    }
}
