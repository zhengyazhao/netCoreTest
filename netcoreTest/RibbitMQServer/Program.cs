
using RabbitMQHelper.Server;
using System;
using System.Text;

namespace RibbitMQServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConsumerServer consumerServer = new ConsumerServer();
            consumerServer.GetMsg("Clent1");
            Console.WriteLine("消费者已启动");
                Console.ReadKey();
        

        }
    }
}
