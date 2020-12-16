using myBusiness.Base;
using myData.Core;
using myData.Repositories;
using myDomain.DTObjects.RequestDTO;
using myDomain.DTObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myBusiness.Message
{
    public class CreateMessageCommand : ICreateCommand<SendMessageRequestDTO>
    {

        private readonly IMessageRepository messageRepository;
        public CreateMessageCommand(IMessageRepository _messageRepository)
        {
            messageRepository = _messageRepository;
        }
        public Task ExecuteAsync(SendMessageRequestDTO message)
        {
            try
            {
                CreateMessageResponseDTO response = new CreateMessageResponseDTO();
                messageRepository.Create(new myData.Entities.Message()
                {
                    Content = message.TextMessage,
                    CreatedDate = DateTime.Now,
                    Id = Guid.NewGuid().ToString()
                });

                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.FromResult<CreateMessageResponseDTO>(new CreateMessageResponseDTO()
                {
                    ExceptionMessage = ex.Message,
                    ExceptionType = ex.GetType().Name,
                    IsBusinessException = true,
                    Success = false
                });
            }
        }
    }
}
