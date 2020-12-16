using System;
using System.Collections.Generic;
using System.Text;

namespace myCore.RabbitMq
{
    public interface IRabbitMqPublisher<Tin, TOut>
    {
        TOut Publish(Tin message);
    }
}
