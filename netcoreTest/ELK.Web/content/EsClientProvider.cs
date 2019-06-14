using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELK.Web.content
{
    public class EsClientProvider:IEsClientProvider
    {
        private readonly IConfiguration _configuration;
        private ElasticClient _client;

        public EsClientProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 获取客户端信息
        /// </summary>
        /// <returns></returns>
        public ElasticClient GetClient()
        {
            if (_client != null)
            {
                return _client;
            }
            initClient();
            return _client;
        }
        /// <summary>
        /// 加载elasticClient
        /// </summary>
        public void initClient()
        {
            var node = new Uri(_configuration["EsUrl"]);
            _client = new ElasticClient(new ConnectionSettings(node).DefaultIndex("Test"));


        }

    }
}
