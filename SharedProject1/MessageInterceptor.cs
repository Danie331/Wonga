using Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shared
{
    public class MessageInterceptor : MessageBase
    {
        private readonly string _responseTemplate = "Hello {0}, I am your father!";
        private IAsyncInterceptor _interceptorClient;

        public MessageInterceptor(IAsyncInterceptor interceptorClient): base()
        {
            _interceptorClient = interceptorClient;
        }

        protected override string GetMessage()
        {
            try
            {
                Regex regex = new Regex(@"(?<=\{)[^}]*(?=\})");
                var match = regex.Match(_value);
                if (match.Success)
                {
                    string name = match.Groups[0].Value;
                    if (_validNames.Contains(name))
                    {
                        return _responseTemplate.Replace("{0}", name);
                    }
                }

                return "Invalid name received";
            }
            catch (Exception ex)
            {
                return "An error occurred parsing the received message: " + ex.Message;
            }
        }

        public void InterceptMessage()
        {
            try
            {
                _interceptorClient.InterceptMessageAsync(msg => {
                    _value = msg;
                    string outputMessage = GetMessage();
                    Console.WriteLine(outputMessage);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while intercepting message: " + ex.Message); // log somewhere
                throw;
            }
        }
    }
}
