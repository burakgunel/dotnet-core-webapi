using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using myConsumerWebApi.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myConsumerWebApi.Base
{
    public static class ConsumerServiceConfiguration
    {
        //IHostedService

        public static void AddConsumers(this IServiceCollection services)
        {
            services.AddSingleton<IHostedService, MessageConsumer>();


        }
    }
}
