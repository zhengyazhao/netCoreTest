using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELK.Web.content
{
   public interface IEsClientProvider
    {
        /// <summary>
        /// 获取客户端信息
        /// </summary>
        /// <returns></returns>
         ElasticClient GetClient();
        /// <summary>
        /// 加载客户端信息
        /// </summary>
        void initClient();
    }
}
