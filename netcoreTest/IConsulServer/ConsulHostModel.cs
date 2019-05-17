using System;
using System.Collections.Generic;
using System.Text;

namespace IConsulServer
{
    /// <summary>
    /// 远程服务器信息
    /// </summary>
    public class ConsulHostModel
    {

        /// <summary>
        /// 远程主机地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 远程端口号
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 服务编号
        /// </summary>
        public string ID { get; set; }
    }

}
