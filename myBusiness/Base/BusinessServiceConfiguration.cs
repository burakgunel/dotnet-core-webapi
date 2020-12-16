using Microsoft.Extensions.DependencyInjection;
using myBusiness.Message;
using myDomain.DTObjects.RequestDTO;
using myDomain.DTObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace myBusiness.Base
{
    public static class BusinessServiceConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ICreateCommand<SendMessageRequestDTO>, CreateMessageCommand>();
            services.AddSingleton<IGetCommand<GetMessageResponseDTO, GetMessageRequestDTO>, GetMessageCommand>();
        }
    }
}
