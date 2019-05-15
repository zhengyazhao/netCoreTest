using System;
using System.Collections.Generic;
using System.Text;

namespace netCoreTest.core.Iserver
{
    public interface IMessageService
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        void SendMsg(string msg);
        /// <summary>
        /// 获取消息
        /// </summary>
        /// <returns></returns>
        string GetMsg();
    }
}
