using RawRabbit;
using RawRabbit.vNext;
using Shared;
using System;
using System.Threading.Tasks;

namespace Client
{
    /// <summary>
    /// Message Dispatcher
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RabbitMqClient rabbitDispatcher = new RabbitMqClient();

                Console.WriteLine("Enter a name: ");
                string name = Console.ReadLine();

                MessageDispatcher dispatcher = new MessageDispatcher(rabbitDispatcher, name);
                dispatcher.DispatchMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred dispatching message: " + ex.ToString());
            }
        }
    }
}
