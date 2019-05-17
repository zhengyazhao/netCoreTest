
using RabbitMQ.Client;
using RabbitMQHelper.IServer;
using RabbitMQHelper.Server;
using System;

namespace RibbitMQClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("消息生产者开始生产数据！");
            Console.WriteLine("输入exit退出!");


            ISendService sendService = new SendService();

            string input;

            do
            {

                input = Console.ReadLine();

                sendService.SendMsg("Clent1", input);
            } while (input.Trim().ToLower() != "exit");


        }
    }
}
