using netCoreTest.core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreTest.core.Iserver
{
    public interface IConnectionServer
    {
      
        /// <summary>
        /// 连接服务
        /// </summary>
        void Connection();
        /// <summary>
        /// 创建消息队列
        /// </summary>
        /// <param name="queName">队列名称</param>
        void CreateQueueDir();
        /// <summary>
        /// 关闭连接
        /// </summary>
        void CloseConnection();
        /// <summary>
        /// 关闭通道
        /// </summary>
        void CloseChannel();


    }
}
