using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
//using Topshelf;

namespace Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //在hosting.json配置监听端口：{"server.urls": "http://*:52725;http://*:52726"}
            var config = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("hosting.json", optional: true)
                      .Build();

            var config2 = new ConfigurationBuilder()
               .SetBasePath(Environment.CurrentDirectory)
               .AddJsonFile("appsettings.json")
               .Build();

            BuildWebHost(args, config).Run();

            //TopShelf服务
            //var rc = HostFactory.Run(x =>                                   //1
            //{
            //    x.Service<MainService>(s =>                                   //2
            //    {
            //        s.ConstructUsing(name => new MainService(args));                //3
            //        s.WhenStarted(tc => tc.Start());                         //4
            //        s.WhenStopped(tc => tc.Stop());                          //5
            //    });
            //    x.RunAsLocalSystem();                                       //6
            //    x.SetDescription("QuartzAPIService");                   //7
            //    x.SetDisplayName("QuartzAPIService");                                  //8
            //    x.SetServiceName("QuartzAPIService");                                  //9
            //});                                                             //10
            //var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());  //11
            //Environment.ExitCode = exitCode;
        }

        public static IWebHost BuildWebHost(string[] args, IConfiguration config) =>

            WebHost.CreateDefaultBuilder(args)
            //.UseConfiguration(config)
            //.UseUrls(config["urls"])
                .UseStartup<Startup>()
                .Build();
    }
}
