using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class MessageDispatcher : MessageBase
    {
        private readonly string _messageTemplate = "Hello my name is, {0}";
        private readonly IAsyncDispatcher _dispatcherClient;
        public MessageDispatcher (IAsyncDispatcher dispatcherClient, string name): base(name)
        {
            _dispatcherClient = dispatcherClient;
        }

        protected override string GetMessage()
        {
            return _messageTemplate.Replace("{0}", "{" + _value + "}");
        }

        public async Task DispatchMessage()
        {
            string message = GetMessage();
            try
            {
                await _dispatcherClient.DispatchMessageAsync(message);
            }
            catch(Exception)
            {
                throw; // for now throw back
            }
        }
    }
}
