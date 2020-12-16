using myCore.Helper;
using myCore.RabbitMq;
using myDomain.DTObjects.RequestDTO;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Net.Http;
using System.Text;

namespace myConsumeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //BusManager.Instance.InitializeBus();
            //BusManager.Instance.Consume<SendMessageRequestDTO>("myWebApi.MessageQueue",
            //    (ex) =>
            //    {
            //        using (var client = new HttpClient())
            //        {
            //            //client.BaseAddress = new Uri("http://localhost:49555/api/message/SendMessage");

            //            var json = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
            //            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            //            var url = "http://localhost:49555/api/message/CreateMessage";

            //            var response = client.PostAsync(url, data);

            //            string result = response.Result.Content.ReadAsStringAsync().Result;

            //        }

            //        return true;
            //    }
            //    );


            //BusManager.Instance.InitializeBus();
            ////var factory = new ConnectionFactory() { HostName = "localhost" };
            //using (var connection = BusManager.Instance.ConnFactory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    channel.QueueDeclare(queue: "myWebApi.MessageQueue", durable: true, exclusive: false, autoDelete: false, arguments: null);

            //    Console.WriteLine(" [*] Waiting for messages.");

            //    var consumer = new EventingBasicConsumer(channel);
            //    consumer.Received += (model, ea) =>
            //    {
            //        var body = ea.Body.ToArray();
            //        //var message = Encoding.UTF8.GetString(body);
            //        var message = ConverterHelper.FromByteArray<SendMessageRequestDTO>(body);
            //        using (var client = new HttpClient())
            //        {
            //            //client.BaseAddress = new Uri("http://localhost:49555/api/message/SendMessage");

            //            var json = Newtonsoft.Json.JsonConvert.SerializeObject(message);
            //            var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");

            //            var url = "http://localhost:49555/api/message/CreateMessage";

            //            var response = client.PostAsync(url, data);

            //            string result = response.Result.Content.ReadAsStringAsync().Result;
            //            channel.BasicAck(ea.DeliveryTag, false);
            //        }


            //        Console.WriteLine(" [x] Received {0}", message);
            //    };
            //    channel.BasicConsume(queue: "myWebApi.MessageQueue", autoAck: true, consumer: consumer);

            //    Console.WriteLine(" Press [enter] to exit.");
            //    Console.ReadLine();
            //}
        }
    }
}
