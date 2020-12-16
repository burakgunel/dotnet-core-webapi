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

                //endpoint config e eklenebilir.
                var request = WebRequest.Create("https://onesignal.com/api/v1/notifications") as HttpWebRequest;

                request.KeepAlive = true;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                //Bunlar config e eklenebilir.
                //app id hash veya encription ile encode decode edilerek kullanılabilir.
                byte[] byteArray = Encoding.UTF8.GetBytes("{"
                                                        + "\"app_id\": \"ebf027b0-459f-4745-bab5-6141b905eb3b\","
                                                        + "\"contents\": {\"en\": \"You have a new message !\"},"
                                                        + "\"include_player_ids\": [\"f5eb4c7e-bec0-455e-bbf4-5d68c804578c\"]}");

                string responseContent = null;


                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var resp = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(resp.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
                if (responseContent == null)
                    throw new Exception("Sending Notification Failed.");

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
