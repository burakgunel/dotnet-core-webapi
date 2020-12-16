using System;
using System.Collections.Generic;
using System.Text;

namespace myCore.RabbitMq
{
    public interface IRabbitMqConsumer<T>
    {
        void Consume();
    }
}
