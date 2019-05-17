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

        public DirectPost(HostModel hostModel)
        {
         
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

        public void CreateRecevice()
        {
            rabbitMQModel.CreateRecevice();
        }
    }
}
