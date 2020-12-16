using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace myData.Core
{
    public class Entity :IEntity
    {
        //Her entity nin bir id si olmak zorundalığı var :) Vakit olursa bak @CanBeImprove
        [BsonId]
        public string Id { get; set; }
    }
}
