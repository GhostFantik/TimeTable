using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;
using NLog;

namespace TimeTableServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger logger = NLogBuilder
                .ConfigureNLog(Directory.GetCurrentDirectory() + "/nlog.config")
                .GetCurrentClassLogger();
            logger.Info("Init main...");
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseNLog()
                .Build();
    }
}
