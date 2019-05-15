using netCoreTest.core;
using netCoreTest.core.ExchangeTypeModel;
using netCoreTest.core.Model;
using System;
using System.Text;

namespace RibbitMQServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //HostModel hostModel = new HostModel();
            //hostModel.UserName = "admin";
            //hostModel.PassWord = "admin";
            //hostModel.Host = "127.0.0.1";
            //hostModel.Port = 5672;
            //RabbitMQModel rabbitMQModel = new RabbitMQModel(hostModel);
            //rabbitMQModel.Connection();
            //rabbitMQModel.GetMsg("Clent");
            DirectPost directPost = new DirectPost();
            directPost.GetMsg();
        

        }
    }
}
