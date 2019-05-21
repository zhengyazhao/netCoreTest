﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OcelotServerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
               .UseUrls("http://localhost:8596")//设置默认启动地址
            //加载ocelotjson文件
            .ConfigureAppConfiguration(conf =>
            {
                conf.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            })
           .UseStartup<Startup>();
    }
}
