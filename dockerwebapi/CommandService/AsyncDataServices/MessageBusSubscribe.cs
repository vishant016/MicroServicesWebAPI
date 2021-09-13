using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommandService.EventProcessing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CommandService.AsyncDataservices
{
    public class MessageBusSubscribe : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IEventProcessor _eventProcessor;
        private IConnection _connection;
        private IModel _channel;
        private object _queueName;

        public MessageBusSubscribe(IConfiguration configuration,IEventProcessor eventProcessor)
        {
            _configuration=configuration;
            _eventProcessor=eventProcessor;
            InitializeRabbitMQ();
        }

        private void InitializeRabbitMQ(){
            var factory=new ConnectionFactory(){HostName=_configuration["RabbitMQHost"],
                Port=int.Parse(_configuration["RabbitMQPort"])};
                 _connection=factory.CreateConnection();
                _channel=_connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "trigger",type: ExchangeType.Fanout);
                _queueName=_channel.QueueDeclare().QueueName;
                _channel.QueueBind(queue: _queueName.ToString(),
                                   exchange: "trigger",
                                   routingKey: "", arguments:null);
                Console.WriteLine("-->Listening on the Message Bus..");
                _connection.ConnectionShutdown+=RabbitMQ_ConnectionShutdown;
                
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer=new EventingBasicConsumer(_channel);
            consumer.Received+=(ModuleHandle,ea)=>{
                Console.WriteLine("--> Event Recieved!");
                var body=ea.Body;
                var notificationMessage=Encoding.UTF8.GetString(body.ToArray());
                _eventProcessor.ProcessEvent(notificationMessage);
            };
            _channel.BasicConsume(queue:_queueName.ToString(),autoAck:true,consumerTag:"",noLocal:false,exclusive:false,arguments:null,consumer:consumer);
            return Task.CompletedTask;

        }
        
        private void RabbitMQ_ConnectionShutdown(object sender,ShutdownEventArgs e){
            Console.WriteLine("-->RabbitMQ Connection Shutdown");
        }
         public override void Dispose(){
            Console.WriteLine("-->Message Bus Dispose");
            if(_connection.IsOpen){
                _channel.Close();
                _connection.Close();
            }
            base.Dispose();
        }
    }
}