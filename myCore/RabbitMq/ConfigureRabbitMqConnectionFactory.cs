using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace myCore.RabbitMq
{
    public static class ConfigureRabbitMqConnectionFactory
    {
        public static void AddRabbitMq(this IServiceCollection services)
        {
            services.AddSingleton(sp =>
           {
               var uri = new Uri("amqps://aoluauiv:ad6hjrBUTMK5fhUMokcR1ZdskyEaL0BU@sparrow.rmq.cloudamqp.com/aoluauiv");
               return new ConnectionFactory
               {
                   Uri = uri,
                   DispatchConsumersAsync = true
               };
           });

          
        }
    }

    
}
