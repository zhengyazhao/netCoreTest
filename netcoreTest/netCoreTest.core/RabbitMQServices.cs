
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreTest.core
{
    public class RabbitMQServices
    {
        private static RabbitMQServices rabbitServicesSingleton;
        public RabbitMQServices()
        {
            rabbitServicesSingleton = new RabbitMQServices();
        }
        private Dictionary<string, IConnection> RabbitMQconn = new Dictionary<string, IConnection>();
        public static RabbitMQServices GetInstance()
        {
            return rabbitServicesSingleton;
        }
        /// <summary>
        /// 添加MQ连接
        /// </summary>
        /// <param name="key">连接名</param>
        /// <param name="value">内容</param>
        public void SetRabbitMqConn(string key, IConnection value)
        {
            if (!RabbitMQconn.ContainsKey(key))
            {
                RabbitMQconn.Add(key, value);
            }
        }
        /// <summary>
        /// 获取rabbitmq所有连接信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, IConnection> GetRabbitMQconn()
        {
            return RabbitMQconn;
        }
        /// <summary>
        /// 移除连接
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool RemoveMQconn(string key)
        {
            bool sflag = true;
            try
            {
                if (RabbitMQconn.ContainsKey(key))
                {
                    RabbitMQconn.Remove(key);
                }
            }
            catch (Exception)
            {
                sflag = false;
                throw;
            }
            return sflag;
        }
    }

}
