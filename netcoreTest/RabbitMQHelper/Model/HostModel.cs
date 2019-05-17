using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQHelper.Model
{
    /// <summary>
    /// 连接实体
    /// </summary>
    public class HostModel
    {
        /// <summary>
        /// 客户端账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 客户端密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 连接地址
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>

        public int Port { get; set; }
        public ExChangeModel ExChangeModel { get; set; }
        /// <summary>
        /// 虚拟路径
        /// </summary>
        public string VirtualHost { get; set; }
    }
    /// <summary>
    /// RabbitMq实体
    /// </summary>
    public class ExChangeModel
    {
        /// <summary>
        /// 队列名称
        /// </summary>
        public string QueueName { get; set; }
        /// <summary>
        /// 路由名称
        /// </summary>
        public string RouteKey { get; set; }
        /// <summary>
        /// 交换机名称
        /// </summary>

        public string ExChangeName { get; set; }
    }
}
