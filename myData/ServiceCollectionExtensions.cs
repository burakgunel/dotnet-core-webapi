
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using myData.Core;
using myData.Entities;
using myData.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace myData
{
  
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IMessageRepository, MessageRepository>();
        }
    }
}
