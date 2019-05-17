using ConsulModels;
using ConsulRegins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreBuild
{
    public static class ApplicationBuilderExtensions
    {

        /// <summary>
        /// 注册consul
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        /// <param name="serviceEntity"></param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            ConsulServiceOption consulServiceOption = new ConsulServiceOption();
            configuration.GetSection("ServiceDiscovery").Bind(consulServiceOption);
            consulServiceOption.Consul = new ConsulRegistryConfig();
            consulServiceOption.Consul.Address = string.Format($"http://localhost:8500");
            consulServiceOption.Consul.Datacenter = "dc1";
            ConsulRegistyHost consulRegistyHost = new ConsulRegistyHost(consulServiceOption.Consul);

            IEnumerable<Uri> address = null;
            if (consulServiceOption.Endpoints != null && consulServiceOption.Endpoints.Length > 0)
            {
                address = consulServiceOption.Endpoints.Select(p => new Uri(p));
            }
            else
            {
                var features = app.Properties["server.Features"] as FeatureCollection;
                address = features.Get<IServerAddressesFeature>().Addresses.Select(p => new Uri(p)).ToArray();
            }

            foreach (var item in address)
            {
                Uri healthCheck = new Uri(item, consulServiceOption.HealthCheckTemplate);
                var test = consulRegistyHost.ServiceRegister(item, consulServiceOption.ServiceName, consulServiceOption.Version, healthCheck, tags: new[] { $"test-/{consulServiceOption.ServiceName}" }).Result;


            }
            return app;
        }


    }
}
