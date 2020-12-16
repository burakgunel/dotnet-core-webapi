using myBusiness.Base;
using myData.Entities;
using myData.Repositories;
using myDomain.DTObjects.RequestDTO;
using myDomain.DTObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBusiness.Message
{
    public class GetMessageCommand : IGetCommand<GetMessageResponseDTO,GetMessageRequestDTO>
    {
        private readonly IMessageRepository messageRepository;
        public GetMessageCommand(IMessageRepository _messageRepository)
        {
            messageRepository = _messageRepository;
        }

        public GetMessageResponseDTO Execute(GetMessageRequestDTO request)
        {
            try
            {
                GetMessageResponseDTO response = new GetMessageResponseDTO();
                var items = messageRepository.GetPagedList(request.PageNumber??0, request.PageLimit??0, s=>s.CreatedDate);
                response.MaxCount = messageRepository.Get().Count();
                response.Result = new List<myDomain.DomainObjects.GetMessageObject>();
                foreach (var item in items)
                {
                    response.Result.Add(new myDomain.DomainObjects.GetMessageObject()
                    {
                        CreatedDate = item.CreatedDate,
                        Content = item.Content
                    });
                }
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                return new GetMessageResponseDTO()
                {
                    ExceptionMessage = ex.Message,
                    ExceptionType = ex.GetType().Name,
                    IsBusinessException = true,
                    Success = false
                };
            }
        }
    }
}
