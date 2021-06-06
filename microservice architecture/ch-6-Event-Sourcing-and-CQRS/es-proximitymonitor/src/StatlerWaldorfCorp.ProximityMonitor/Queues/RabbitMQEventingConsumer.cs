using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace StatlerWaldorfCorp.ProximityMonitor.Queues
{
    public class RabbitMQEventingConsumer : EventingBasicConsumer
    {
        public RabbitMQEventingConsumer(IAMQPConnectionFactory factory) : base(factory.ConnectionFactory().CreateConnection().CreateModel())
        {            
        }
    }
}