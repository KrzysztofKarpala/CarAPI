using CarAPI.Core.Repository;
using Messaging.Shared;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace CarAPI.Infrastructure.Mongo.Repositories
{
    public class RabbitMqCarApiRepository : IRabbitMqCarApiRepository
    {
        private readonly IModel _channel;
        private readonly RabbitMqSettings _rabbitMqSettings;

        public RabbitMqCarApiRepository(IModel channel, RabbitMqSettings rabbitMqSettings)
        {
            _channel = channel;
            _rabbitMqSettings = rabbitMqSettings;
        }
        public void SendMessage<T>(T message) where T : class
        {
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            _channel.BasicPublish(exchange: _rabbitMqSettings.ExchangeName,
                routingKey: "",
                basicProperties: null,
                body: body);
        }
    }
}
