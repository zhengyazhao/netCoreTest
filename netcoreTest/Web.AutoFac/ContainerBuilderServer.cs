using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Iserver;
using Web.Server;

namespace Web.AutoFac
{
    /// <summary>
    /// 构建
    /// </summary>
    public class ContainerBuilderServer
    {
        private static IContainer container { get; set; }
        public void Builder()
        {
            var builder =new  ContainerBuilder();

            builder.RegisterType<IUserSever>().As<UserServer>();
            container = builder.Build();
        
            
        }
    }
}
