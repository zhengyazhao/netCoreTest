using Microsoft.Extensions.Configuration;
using netcoreModel.ESModel;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;
using Web.ElasticSearchHelper.IServer;

namespace Web.ElasticSearchHelper
{

    public class ESHelper
    {
        private readonly IConfiguration _configuration;
        private ElasticClient _client;
        /// <summary>
        /// 辅助类
        /// </summary>
        public ESHelper()
        {

            var setting = getConnectionSettings();
            _client = new ElasticClient(setting);

        }
        private ConnectionSettings getConnectionSettings()
        {
            var node = new Uri("http://10.30.61.74:9200/");
            var setting = new ConnectionSettings(node);
            //setting.ConnectionLimit(80);//连接最大并发数
            //setting.MaximumRetries(5);//最大重试次数
            //setting.MaxRetryTimeout(new TimeSpan(5000));//重试超时时间
     
            return setting;
        }
        /// <summary>
        /// 添加索引信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        public void AddIndex<T>(IEsModel model)
        {
           
       
            _client.Index(model, s => s.Index("ceshi").Type("nice"));
        }
        /// <summary>
        /// 判断索引是否存在
        /// </summary>
        public bool IndexExists(string indexName)
        {
         return _client.IndexExists(indexName).Exists;
           
        }
        /// <summary>
        /// 删除索引
        /// </summary>
        /// <param name="indexName"></param>
        /// <returns></returns>
        public bool RemoveIndec(string indexName)
        {
          return  _client.DeleteIndex(indexName).IsValid;
        }
        public void CreateIndex(string index)
        {
            _client.CreateIndex(index);
        }
        public IPutMappingResponse GetModelAll()
        {
            var result = _client.Map<UserModel>(m=>m.AutoMap());
            return result;
        }

    }

}
