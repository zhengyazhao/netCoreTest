using netCoreTest.core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreTest.core.ExchangeTypeModel
{

    /// <summary>
    /// Direct模式发送
    /// </summary>
    public class DirectPost
    {


        RabbitMQModel rabbitMQModel;

        public DirectPost()
        {
            HostModel hostModel = new HostModel();
            hostModel.UserName = "admin";
            hostModel.PassWord = "admin";
            hostModel.Host = "127.0.0.1";
            hostModel.Port = 5672;
            hostModel.ExChangeModel =new ExChangeModel {
                ExChangeName = "ClentName",
                QueueName = "Clent",
                RouteKey = "ClentRoute"
            };
            rabbitMQModel = new RabbitMQModel(hostModel);
            rabbitMQModel.Connection();

        }
        public void CreateQueue()
        {
            rabbitMQModel.CreateQueueDir();
        }
        public void SendMsg(string msg)
        {
            rabbitMQModel.SendMsg(msg);
        }
        public void GetMsg()
        {
            rabbitMQModel.GetMsg();
        }
    }
}
