using myData.Core;
using myData.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace myData.Repositories
{
    public class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
