using myDomain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace myDomain.DTObjects.RequestDTO
{
    [Serializable]
    public class SendMessageRequestDTO : BaseRequestDTO
    {
        public string TextMessage { get; set; }
    }
}
