using Microsoft.AspNetCore.Mvc;
using myCore.Helper;
using myCore.RabbitMq;
using myDomain.DTObjects.RequestDTO;
using myDomain.DTObjects.ResponseDTO;

namespace myWebApi.Controllers
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IRabbitMqPublisher<SendMessageRequestDTO, SendMessageResponseDTO> _sendMessagePublisher;
        public MessageController(IRabbitMqPublisher<SendMessageRequestDTO, SendMessageResponseDTO> sendMessagePublisher)
        {
            _sendMessagePublisher = sendMessagePublisher;
        }

        [HttpPost]
        public SendMessageResponseDTO SendMessage(SendMessageRequestDTO request)
        {

            return ServiceExecuterHelper<SendMessageRequestDTO, SendMessageResponseDTO>.Execute(
                _sendMessagePublisher.Publish,
                request,
                (ex) => { return ServiceException<SendMessageResponseDTO>.onException(ex); });
        }


    }
}