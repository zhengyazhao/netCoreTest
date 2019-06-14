using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace netcoreModel.ESModel
{
    [ElasticsearchType(Name="UserModel",IdProperty ="Id")]//Name = “文档的类型”,IdProperty = “文档的唯一键字段名”
    public class UserModel:IEsModel
    {
        /// <summary>
        /// 編號
        /// </summary>
        [Number(NumberType.Integer, Name = "Id")]//数字类型 +名称
        public long Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Keyword(Name ="UserName",Index =true)]//不需要分词的字符串，名称，index=是否建立索引
        public string UserName { get; set; }
        /// <summary>
        /// text 分词,Analyzer = "ik_max_word"
        /// </summary>
        [Text(Name = "Dic", Index = true)]
        public string Dic { get; set; }//需要分词的字符串，name=名称,index=是否建立索引,Analyzer=分词器
        /// <summary>
        /// 当前状
        /// </summary>
        [Number(NumberType.Integer, Name = "State")]
        public int State { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Boolean(Name = "Deleted")]
        public bool Deleted { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        [Date(Name = "AddTime")]
        public DateTime AddTime { get; set; }

    }
}
