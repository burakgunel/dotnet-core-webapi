using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using myData.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace myData.Entities
{
    public class Message : AuditableEntity
    {
        public string Content { get; set; }
    }
}
