using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TimeTableServer.Models;
using Microsoft.EntityFrameworkCore;
using TimeTableServer.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Http;
using TimeTableServer.Services.VK;
using System.Threading;
using NLog.Web;
namespace TimeTableServer
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
            // Adding a DB
            string dataConnection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TimeTableContext>(options => {
                options.UseMySql(dataConnection);
            });
            // Adding the service TimeTableService
            services.AddTransient<ITimeTableService, TimeTableService>();
            //services.AddTransient<IVkBotService, VkBotService>();
            //services.AddTransient<Utils.UtilsConvert>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILogger<Startup> logger)
        {
            logger.LogInformation("StartUp!!!!!!");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //logger.LogError("Это норм??");
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
