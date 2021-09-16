using CovidReader.Controllers;
using CovidReader.Controllers.UseCases;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidReader.Web
{
    public class Program
    {
        public static IAppController WebController { get; private set; }

        public static void Main(string[] args)
        {
            WebController = new WebController(ApiRepositoryUseCase.UseSqlite(), CovidRepositoryUseCase.UseInMemory());
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
