using System;
using System.Collections.Generic;
using System.Text;

namespace myDomain.Base
{
    public class BaseResponseDTO 
    {
        public bool Success { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public bool IsBusinessException { get; set; }

    }
}
