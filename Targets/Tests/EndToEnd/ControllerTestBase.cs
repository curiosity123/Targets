using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Targets.Infrastructure.Repositories;

namespace Targets.Tests.EndToEnd
{
    public abstract class ControllerTestsBase
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;

        protected ControllerTestsBase()
        {
            //var b = WebHost.CreateDefaultBuilder()
          //      .UseStartup<Startup>();
            Server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
    //.UseContentRoot(@"C:\Projects\AspNetCore\Targets\Targets\wwwroot")
    .UseConfiguration(new ConfigurationBuilder()
        .SetBasePath(@"C:\Projects\AspNetCore\Targets\Targets")
        .AddJsonFile("appsettings.json")
        .Build()
    )
    .UseStartup<Startup>());

            //            .UseEnvironment("Development")
            //.UseConfiguration(new ConfigurationBuilder()
            //.SetBasePath(projectDir)
            //    .AddJsonFile("appsettings.json")
            //    .Build()).UseStartup<Startup>());//.UseStartup<TestStartup>());


            Client = Server.CreateClient();
            
        }
 

        protected static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
