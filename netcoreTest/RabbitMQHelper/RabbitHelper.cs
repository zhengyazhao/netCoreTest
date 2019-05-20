
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQHelper.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RabbitMQHelper
{
    public class RabbitHelper
    {
        private readonly ConnectionFactory factory = null;
        public RabbitHelper(HostModel hostModel)
        {
            // 创建连接工厂
            factory = new ConnectionFactory
            {
                UserName = hostModel.UserName,//连接用户名
                Password = hostModel.PassWord,//连接密码
                HostName = "localhost",//连接地址
                Port = hostModel.Port,//端口号
                //VirtualHost = hostModel.VirtualHost
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
        /// 发送消息到消息队列
        /// </summary>
        /// <param name="conn">连接地址</param>
        /// <param name="queueName">队列名称</param>
        /// <param name="msg">发送的消息</param>
        /// <param name="exchangeModel">交换机实体</param>
        /// <returns></returns>
        public bool sendMsg(IConnection conn, string queueName, string msg, ExchangeModel exchangeModel)
        {
            bool sflag = true;
            try
            {
                //var channel = conn.CreateModel();
                using (var channel = conn.CreateModel())
                {

                    //1交换机，交换机类型
                    channel.ExchangeDeclare(exchangeModel.ExchangeName, exchangeModel.ExchangeType);
                    //队列名称，是否持久化，独占的队列，不使用时是否自动删除，
                    channel.QueueDeclare(queueName, exchangeModel.Durable, false, false, null);
                    //转换成byte数组
                    var sendBytes = Encoding.UTF8.GetBytes(msg);
                    //设置持久化参数
                    var properties = channel.CreateBasicProperties();
                    properties.DeliveryMode = 2;//1表示不持久，2表示持久化
                    if (!exchangeModel.Durable)
                    {
                        properties = null;
                    }
                    //发送消息：交换机名称，路由，持久化参数，消息内容
                    channel.BasicPublish(exchangeModel.ExchangeName, exchangeModel.RouteKey[0], properties, sendBytes);
                }
            }
            catch (Exception)
            {

                sflag = true;
                throw;
            }
            return sflag;
        }
        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="connection">连接</param>
        /// <param name="queueName">队列名称</param>
        /// <param name="exchangeModel">交换机实体</param>
        /// <returns></returns>
        public string ConsumMsg(IConnection connection, string queueName, ExchangeModel exchangeModel)
        {
            string msg = string.Empty;
            var channel = connection.CreateModel();

            foreach (var item in exchangeModel.RouteKey)
            {
                //队列绑定：队列名称，交换机名称，路由
                channel.QueueBind(queueName, exchangeModel.ExchangeName, item, null);
            }

            var consumer = new EventingBasicConsumer(channel);
            //接收到消息事件
            consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                msg = message;
                //判断是否是正常消息
                if (ea.RoutingKey == "ClentRoute.error")
                {
                    Console.WriteLine($"收到异常消息： {message}");
                }
                else
                {
                    Console.WriteLine($"收到正常消息： {message}");
                }


                //确认该消息已被消费
                channel.BasicAck(ea.DeliveryTag, false);
            };
            //启动消费者 设置为手动应答消息
            channel.BasicConsume(queueName, false, consumer);
            return msg;

        }

    }
}