using netCoreTest.core.Iserver;
using netCoreTest.core.Model;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreTest.core
{
    public class RabbitMQModel : IRabbitMqService
    {

        private readonly ConnectionFactory factory = null;
        private IModel channel;
        private IConnection connetction;
        readonly string exchangeName;//交换机名称
        readonly string routeKey;//路由名称
        readonly string queueName;///队列名称
        public RabbitMQModel(HostModel model)
        {
            /// <summary>
            /// 创建连接工厂
            /// </summary>
            factory = new ConnectionFactory
            {
                UserName = model.UserName,
                Password = model.PassWord,
                HostName = "localhost",
                Port = model.Port,
            };
            exchangeName = model.ExChangeModel.ExChangeName;
            routeKey = model.ExChangeModel.RouteKey;
            queueName = model.ExChangeModel.QueueName;
        }
        /// <summary>
        /// 创建连接
        /// </summary>
        public void Connection()
        {
            try
            {
                //创建连接
                connetction = factory.CreateConnection();
                //创建信道
                channel = connetction.CreateModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void CreateQueueDir()
        {
            //定义一个direct类型的交换机
            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, false, false, null);
            //定义一个队列
            channel.QueueDeclare(queueName, false, false, false, null);
            //将队列绑定交换机
            channel.QueueBind(queueName, exchangeName, routeKey, null);


        }
        public void CreateQueueDirTop(string queName)
        {

            /////定义一个direct类型的交换机
            //channel.ExchangeDeclare(exchangeName,   ExchangeType.Topic, false, false, null);
            ////定义一个队列
            //channel.QueueDeclare(queName, false, false, false, null);
            ////讲队列绑定到交换机
            //channel.QueueBind(queName, exchangeName, routeKey, null);

            //Console.WriteLine("\n 连接成功，请输入消息，输入exit退出");
        }
        public void SendMsg(string msg)
        {
            var sendBytes = Encoding.UTF8.GetBytes(msg);
            channel.BasicPublish(exchangeName, routeKey, null, sendBytes);
        }

        public void CloseChannel()
        {
            channel.Close();
        }

        public void CloseConnection()
        {
            connetction.Close();
        }

        public string GetMsg()
        {
            //事件基本消费者
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            string msg = null;
            //接收到消息事件
            consumer.Received += (ch, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                msg = message;
                Console.WriteLine($"收到消息： {message}");
                //确认该消息已被消费
                channel.BasicAck(ea.DeliveryTag, false);
            };
            //启动消费者 设置为手动应答消息
            channel.BasicConsume(queueName, false, consumer);
            Console.WriteLine("消费者已启动");
            Console.ReadKey();
            CloseConnection();
            CloseChannel();
            return msg;
        }


    }
}
