using myBusiness.Base;
using myData.Repositories;
using myDomain.DTObjects.RequestDTO;
using myDomain.DTObjects.ResponseDTO;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace myBusiness.Message
{
    public class CreateMessageCommand : ICreateCommand<SendMessageRequestDTO>
    {

        private readonly IMessageRepository messageRepository;
        private readonly ISendPushNotificationCommand sendPushNotificationCommand;
        public CreateMessageCommand(IMessageRepository _messageRepository, ISendPushNotificationCommand _sendPushNotificationCommand)
        {
            messageRepository = _messageRepository;
            sendPushNotificationCommand = _sendPushNotificationCommand;
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

                sendPushNotificationCommand.SendPushNotification(message.TextMessage);
                

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
