using RabbitMQ.Client;
using RabbitMQHelper.core;
using RabbitMQHelper.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RabbitMQHelper.Server
{
    public class ConsumerServer
    {
        IConnection connection;//rabbitmq连接地址
        private object obj = new object();//对象
        RabbitHelper rabbitHelper;//rabbitHelper类

        public ConsumerServer()
        {
            RabbitMQSingleton rabbitMQSingleton = RabbitMQSingleton.GetInstance();
            Dictionary<string, IConnection> connDictionary = rabbitMQSingleton.GetRabbitMQconn();
            if (connDictionary != null && connDictionary.Count > 0)
            {
                connection = connDictionary["test"];
            }
            else
            {
                HostModel hostModel = new HostModel();
                hostModel.UserName = "admin";
                hostModel.PassWord = "admin";
                hostModel.Host = "127.0.0.1";
                hostModel.Port = 5672;
                //hostModel.VirtualHost = "/";

                lock (obj)
                {
                    rabbitHelper = new RabbitHelper(hostModel);
                    connection = rabbitHelper.Connection();
                    rabbitMQSingleton.SetRabbitMqConn("test", connection);
                }
            }
        }
        public string GetMsg(string queueName)
        {
          return  rabbitHelper.ConsumMsg(connection, queueName, false);
        }
    }
}