using netCoreTest.core;
using netCoreTest.core.ExchangeTypeModel;
using netCoreTest.core.Model;
using RabbitMQ.Client;
using System;

namespace RibbitMQClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("消息生产者开始生产数据！");
            Console.WriteLine("输入exit退出!");
            DirectPost directPost = new DirectPost();
            directPost.CreateQueue();
            string input;
           
            do
            {
                input = Console.ReadLine();
                directPost.SendMsg(input);

            } while (input.Trim().ToLower() != "exit");


        }
    }
}
