using RawRabbit;
using RawRabbit.vNext;
using Shared;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Wonga
{
    /// <summary>
    /// Message receiver
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RabbitMqClient rabbitInterceptor = new RabbitMqClient();
                MessageInterceptor interceptor = new MessageInterceptor(rabbitInterceptor);

                interceptor.InterceptMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred receiving message: " + ex.ToString());
            }
        }
    }
}
