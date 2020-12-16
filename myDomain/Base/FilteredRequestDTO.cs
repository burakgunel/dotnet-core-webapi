using System;
using System.Collections.Generic;
using System.Text;

namespace myDomain.Base
{
    public class FilteredRequestDTO : BaseRequestDTO
    {
        public int? PageLimit { get; set; }
        public int? PageNumber { get; set; }
    }
}
