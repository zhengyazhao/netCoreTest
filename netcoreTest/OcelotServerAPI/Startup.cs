using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;

namespace OcelotServerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication("TestKey", o =>
                    {
                        o.Authority = "";//验证的服务器地址
                        o.RequireHttpsMetadata = false;//不启用https验证
                        o.ApiName = "UserApi";//要认证的服务名称
                    });

            services
                .AddOcelot(Configuration) //添加ocelot
                .AddConsul()              //添加consul服务注册
                .AddPolly();              //添加polly容灾
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseOcelot().Wait();//添加ocelot信道
            app.UseAuthentication();//添加authen认证信道
        }
    }
}
