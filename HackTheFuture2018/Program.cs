using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HackTheFuture2018.Client;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HackTheFuture2018
{
    public class Program
    {
        private static readonly HtfClient htfClient = new HtfClient();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            htfClient.GetChallenge();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
