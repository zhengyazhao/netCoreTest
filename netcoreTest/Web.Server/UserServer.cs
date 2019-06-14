using System;
using System.Collections.Generic;
using System.Text;
using Web.Iserver;

namespace Web.Server
{
    public class UserServer : IUserSever
    {

        public void AddUser()
        {
            Console.WriteLine("添加用户成功！");
        }

        public string GetUerListString(int id)
        {
            string msg = string.Empty;
            try
            {
                msg = string.Format($"获取用户张三成功!!!!!!!!!!!!!!");
            }
            catch (Exception)
            {
                msg = string.Format($"获取用户接口异常");
            }

            return msg;
        }
    }
}
