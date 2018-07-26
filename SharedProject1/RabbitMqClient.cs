using RawRabbit;
using RawRabbit.vNext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    /// <summary>
    /// RabbitMQ client
    /// </summary>
    public class RabbitMqClient : IAsyncDispatcher, IAsyncInterceptor
    {
        private IBusClient _client;
        public RabbitMqClient()
        {
            InitClient();
        }      

        private void InitClient()
        {
            var busConfig = new RawRabbit.Configuration.RawRabbitConfiguration
            {
                Username = "guest",
                Password = "guest",
                Port = 5672,
                VirtualHost = "/",
                Hostnames = { "localhost" }
            };

            _client = BusClientFactory.CreateDefault(busConfig);
        }

        public async Task DispatchMessageAsync(string message)
        {
             await Task.Run(() => { _client.PublishAsync(message); });
        }

        public void InterceptMessageAsync(Action<string> messagedReceivedAction)
        {
            _client.SubscribeAsync<string>(async (message, mc) => {
                messagedReceivedAction(message);
            });
        }
    }
}
