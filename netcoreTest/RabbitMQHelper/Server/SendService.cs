using RabbitMQ.Client;
using RabbitMQHelper.core;
using RabbitMQHelper.IServer;
using RabbitMQHelper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQHelper.Server
{
    public class SendService : ISendService
    {
        IConnection connection;//rabbitmq连接地址
        private object obj=new object();//对象
        RabbitHelper rabbitHelper;//rabbitHelper类

        public SendService()
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
        public bool CloseConnection()
        {
            throw new NotImplementedException();
        }
        public void SendMsg(string queueName, string msg)
        {
            ExchangeModel exchangeModel = new ExchangeModel();
            exchangeModel.Durable = false;
            exchangeModel.ExchangeName = "ClentName";
            exchangeModel.ExchangeType = ExchangeType.Direct;
            exchangeModel.RouteKey = "ClentRoute";
            rabbitHelper.sendMsg(connection, queueName, msg, exchangeModel);
        }

        //public void SendMsg(string msg)
        //{

        //    throw new NotImplementedException();
        //}
    }
}
