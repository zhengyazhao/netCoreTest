using System;
using System.Collections.Generic;
using ELK.Web.content;
using Microsoft.AspNetCore.Mvc;

using Nest;

using netcoreModel.ESModel;
using Web.ElasticSearchHelper;

namespace ELK.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public ValuesController()
        {

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpPost]
        [Route("Search")]
        public string Search([FromBody]UserModel userModel)
        {
            //UserModel userModel = new UserModel();
            //userModel.AddTime = DateTime.Now;
            //userModel.Deleted = false;
            //userModel.Dic = "超时的人，的哈哈哈测试测试哈哈哈哈";
            //userModel.Id = 1;
            //userModel.State = 2;
            //userModel.UserName = "zhengyazhao";
            ESHelper eSHelper = new ESHelper();
            eSHelper.CreateIndex("ceshi");
            eSHelper.AddIndex<UserModel>(userModel);
            return "获取成功";
        }
    }
}
