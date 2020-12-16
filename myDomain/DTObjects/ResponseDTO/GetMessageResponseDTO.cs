using myDomain.Base;
using myDomain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace myDomain.DTObjects.ResponseDTO
{
    public class GetMessageResponseDTO : FilteredResponseDTO
    {
        public List<GetMessageObject> Result { get; set; }
    }
}
