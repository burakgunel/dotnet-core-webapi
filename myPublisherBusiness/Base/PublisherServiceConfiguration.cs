using Microsoft.Extensions.DependencyInjection;
using myCore.RabbitMq;
using myDomain.DTObjects.RequestDTO;
using myDomain.DTObjects.ResponseDTO;
using myPublisherBusiness.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace myPublisherBusiness.Base
{
   
    public static class PublisherServiceConfiguration
    {
        public static void AddPublishers(this IServiceCollection services)
        {
            services.AddSingleton<IRabbitMqPublisher<SendMessageRequestDTO,SendMessageResponseDTO>, MessagePublisher>();


        }
    }
}
