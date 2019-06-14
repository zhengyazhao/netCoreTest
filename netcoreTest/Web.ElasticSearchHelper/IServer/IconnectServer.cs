using System;
using System.Collections.Generic;
using System.Text;
using Nest;
namespace Web.ElasticSearchHelper.IServer
{
    public interface IConnectServer
    {
        /// <summary>
        /// 获取客户端信息
        /// </summary>
        /// <returns></returns>
        ElasticClient GetClient();

        /// <summary>
        /// 连接客户端
        /// </summary>
        void initClient();

    }
}
