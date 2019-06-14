using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Iserver
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public interface IUserSever
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        void AddUser();

        /// <summary>
        /// 根据用户id获取用户list集合
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        string GetUerListString(int id);
    }
}
