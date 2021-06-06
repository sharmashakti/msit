using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Linq;
using Microsoft.Extensions.Logging;
using StatlerWaldorfCorp.EventProcessor.Models;
using System;

namespace StatlerWaldorfCorp.EventProcessor.Queues.AMQP
{
    public class AMQPConnectionFactory  :IAMQPConnectionFactory
    {
        protected AMQPOptions amqpOptions;
         public ConnectionFactory connectionFactory = new ConnectionFactory();

        public AMQPConnectionFactory(           
            IOptions<AMQPOptions> serviceOptions) 
        {
            this.amqpOptions = serviceOptions.Value;

           this.connectionFactory.UserName = amqpOptions.Username;
            this.connectionFactory.Password = amqpOptions.Password;
            this.connectionFactory.VirtualHost = amqpOptions.VirtualHost;
            this.connectionFactory.HostName = amqpOptions.HostName;
            this.connectionFactory.Uri = new Uri(amqpOptions.Uri);           
        }

         public ConnectionFactory ConnectionFactory(){
            return this.connectionFactory;            
        }
    }

    public interface IAMQPConnectionFactory{
        ConnectionFactory ConnectionFactory();
    } 
}