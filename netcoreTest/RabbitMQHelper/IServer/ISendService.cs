using RabbitMQHelper.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQHelper.IServer
{
    /// <summary>
    /// 消息生产者接口
    /// </summary>
    public interface ISendService
    {

        /// 发送消息
        /// </summary>
        /// <param name="msg">消息体</param>
        void SendMsg(string queueName, string msg);
        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns></returns>

        bool CloseConnection();
     
    }
}
