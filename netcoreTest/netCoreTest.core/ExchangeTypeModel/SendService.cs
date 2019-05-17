using netCoreTest.core.Iserver;
using netCoreTest.core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreTest.core.ExchangeTypeModel
{
    public class SendService : ISendService
    {
        public bool CloseConnection()
        {
            throw new NotImplementedException();
        }
        private object obj;
        public bool Connection(HostModel hostModel)
        {
            bool sflag = true;
            RabbitMQModel rabbitMQModel = null;
            Dictionary<string, RabbitMQModel> rabbitmqDictionary = RabbitMQServices.GetInstance().GetRabbitMQconn();
            if (rabbitmqDictionary.Count > 0)
            {
                rabbitMQModel = rabbitmqDictionary["test"];
            }
            else
            {
                rabbitMQModel = new RabbitMQModel(hostModel);
                lock (rabbitmqDictionary)
                {
                    RabbitMQServices.GetInstance().SetRabbitMqConn("test", rabbitMQModel);
                    rabbitMQModel.Connection();
                }
            }
            return sflag;
        }

        public void CreateQueue()
        {
            throw new NotImplementedException();
        }

        public void CreateQueue(string queueName)
        {
            throw new NotImplementedException();
        }

        public void SendMsg(string msg)
        {
            throw new NotImplementedException();
        }
    }
}
