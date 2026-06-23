using RabbitMQ.Client;
using Newtonsoft.Json;
using System.Text;

namespace Orders.Infrastructure.Messaging
{
    public class RabbitMqService : IMessageBusService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string _exchange = "order-service";

        public RabbitMqService()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection("order-service-publisher");
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(
            exchange: _exchange,
            type: ExchangeType.Direct,
            durable: true,
            autoDelete: false,
            arguments: null
        );
        }

        public void Publish(object data, string routingKey)
        {
            var type = data.GetType();

            var payload = JsonConvert.SerializeObject(data);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            Console.WriteLine($"{type.Name} Published");

            _channel.BasicPublish(_exchange, routingKey, null, byteArray);
        }
    }
}
