using System;
using System.Collections.Generic;
using System.Text;

namespace myData.Core
{
    public class AuditableEntity : Entity
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    }
}
