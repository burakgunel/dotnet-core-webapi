﻿using System;
using System.Collections.Generic;
using System.Text;

namespace myData.Core
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
