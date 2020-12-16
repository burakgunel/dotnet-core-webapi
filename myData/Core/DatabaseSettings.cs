using System;
using System.Collections.Generic;
using System.Text;

namespace myData.Core
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
