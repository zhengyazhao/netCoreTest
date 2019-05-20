using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQHelper.Model
{
    /// <summary>
    /// 交换机实体
    /// </summary>
    public class ExchangeModel
    {
        /// <summary>
        /// 交换机名称
        /// </summary>
        public string ExchangeName { get; set; }
        /// <summary>
        /// 交换机类型
        /// </summary>
        public string ExchangeType { get; set; }
        /// <summary>
        /// 路由key
        /// </summary>
        public List<string> RouteKey { get; set; }
        /// <summary>
        /// 是否持久化
        /// </summary>
        public bool Durable { get; set; }
    }
   
}
