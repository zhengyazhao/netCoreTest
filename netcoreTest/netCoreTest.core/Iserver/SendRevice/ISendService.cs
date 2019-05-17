
using netCoreTest.core.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace netCoreTest.core.Iserver
{
    /// <summary>
    /// 消息生产者接口
    /// </summary>
    public interface ISendService
    {
           
        /// <summary>
        /// 创建消息队列
        /// </summary>
        /// <param name="queueName">队列名称</param>
        void CreateQueue(string queueName);
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg">消息体</param>
        void SendMsg(string msg);
        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns></returns>

        bool CloseConnection();
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <returns></returns>
        bool Connection(HostModel hostModel);
    }
}