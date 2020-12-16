using Microsoft.Extensions.Logging;
using myBusiness.Base;
using myBusiness.Message;
using myCore.RabbitMq;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myConsumerWebApi.Base
{
    public abstract class ConsumerBase<TMessage> : RabbitMqClientBase
    {
        private readonly ICreateCommand<TMessage> _createCommand;
        protected abstract string RabbitMqQueueName { get; }

        public ConsumerBase(
            ICreateCommand<TMessage> createCommand,
            ConnectionFactory connectionFactory) :
            base(connectionFactory)
        {
            _createCommand = createCommand;
        }

        protected virtual async Task OnEventReceived(object sender, BasicDeliverEventArgs eventArgs)
        {
            try
            {
                var body = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
                var message = JsonConvert.DeserializeObject<TMessage>(body);

                await _createCommand.ExecuteAsync(message);
            }
            catch (Exception ex)
            {
                throw new Exception( "Error while retrieving message from queue.",ex);
            }
            finally
            {
                Channel.BasicAck(eventArgs.DeliveryTag, false);
            }
        }

    }
}
