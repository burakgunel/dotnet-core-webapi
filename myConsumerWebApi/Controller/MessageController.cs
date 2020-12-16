using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myBusiness.Base;
using myCore.Helper;
using myDomain.DTObjects.RequestDTO;
using myDomain.DTObjects.ResponseDTO;

namespace myConsumerWebApi.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        private readonly IGetCommand<GetMessageResponseDTO, GetMessageRequestDTO> _getMessageCommand;
        public MessageController(IGetCommand<GetMessageResponseDTO, GetMessageRequestDTO> getMessageCommand)
        {
            _getMessageCommand = getMessageCommand;
        }

        [HttpPost]
        public GetMessageResponseDTO GetMessage(GetMessageRequestDTO request)
        {
            return ServiceExecuterHelper<GetMessageRequestDTO, GetMessageResponseDTO>.Execute(
              _getMessageCommand.Execute,
              request,
              (ex) => { return ServiceException<GetMessageResponseDTO>.onException(ex); });
        }
    }
}