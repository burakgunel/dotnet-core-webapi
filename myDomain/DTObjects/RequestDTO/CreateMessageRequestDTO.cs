using myDomain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace myDomain.DTObjects.RequestDTO
{
    public class CreateMessageRequestDTO :BaseRequestDTO
    {
        public string TextMessage { get; set; }
    }
}
