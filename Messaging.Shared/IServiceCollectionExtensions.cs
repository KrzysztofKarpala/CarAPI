using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace Messaging.Shared
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection SetUpRabbitMq(this IServiceCollection services, IConfiguration config)
        {
            var configSection = config.GetSection("RabbitMqSettings");
            var settings = new RabbitMqSettings();
            configSection.Bind(settings);

            services.AddSingleton<RabbitMqSettings>(settings);

            services.AddSingleton<IConnectionFactory>(sp => new ConnectionFactory
            {
                HostName = settings.HostName,
                DispatchConsumersAsync = true
            });

            services.AddSingleton<ModelFactory>();
            services.AddSingleton(sp => sp.GetRequiredService<ModelFactory>().CreateChannel());

            return services;
        }

        public class ModelFactory : IDisposable
        {
            private readonly IConnection _connection;
            private readonly RabbitMqSettings _settings;

            public ModelFactory(IConnectionFactory connectionFactory, RabbitMqSettings settings)
            {
                _connection = connectionFactory.CreateConnection();
                _settings = settings;
            }

            public IModel CreateChannel()
            {
                var channel = _connection.CreateModel();
                channel.ExchangeDeclare(exchange: _settings.ExchangeName, type: _settings.ExchangeType);
                return channel;
            }

            public void Dispose()
            {
                _connection.Dispose();
            }
        }
    }
}
