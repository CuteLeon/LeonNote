using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LeonNoteCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls(new string[] {
                    /* 部署地址和端口:
                     * 0.0.0.0 : 公网公开访问
                     * localhost : 仅本地访问
                     * 1304 : 端口
                     */ 
                    "http://0.0.0.0:1304",
                })
                .UseStartup<Startup>();
    }
}
