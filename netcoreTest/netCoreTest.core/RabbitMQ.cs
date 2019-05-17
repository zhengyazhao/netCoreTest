using netCoreTest.core.Model;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreTest.core
{
    public class RabbitMQ
    {
        private readonly ConnectionFactory factory = null;
        public RabbitMQ(HostModel hostModel)
        {
            // 创建连接工厂
            factory = new ConnectionFactory
            {
                UserName = hostModel.UserName,//连接用户名
                Password = hostModel.PassWord,//连接密码
                HostName = "localhost",//连接地址
                Port = hostModel.Port,//端口号
                VirtualHost = hostModel.VirtualHost
            };
        }
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        public IConnection Connection()
        {

            IConnection connection = null;
            try
            {
                factory.AutomaticRecoveryEnabled = true;//自动重连
                connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                throw new Exception("连接失败!~~~~~");
            }
            return connection;
        }
        /// <summary>
        /// rabbitmq发送消息
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="queueName"></param>
        /// <param name="msg"></param>
        /// <param name="exchangeName"></param>
        /// <param name="routeKey"></param>
        /// <param name="durable"></param>
        /// <returns></returns>
        public bool sendMsg(IConnection conn, string queueName, string msg, string exchangeName, string exchangeType, string routeKey, bool durable = true)
        {
            bool sflag = true;
            try
            {
                RabbitMQServices rabbitMQServices = RabbitMQServices.GetInstance();

                using (var channel = conn.CreateModel())
                {

                    //1交换机，交换机类型
                    channel.ExchangeDeclare(exchangeName, exchangeType);

                    //队列名称，是否持久化
                    channel.QueueDeclare(queueName, durable);
                    //转换成byte数组
                    var sendBytes = Encoding.UTF8.GetBytes(msg);
                    //设置持久化参数
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;//1表示不持久，2表示持久化
                    if (!durable)
                    {
                        properties = null;
                    }
                    //发送消息：交换机名称，路由，持久化参数，消息内容
                    channel.BasicPublish(exchangeName, routeKey, properties, sendBytes);
                }
            }
            catch (Exception)
            {

                sflag = true;
                throw;
            }
            return sflag;
        }


    }
}
