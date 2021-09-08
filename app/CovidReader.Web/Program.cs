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
        public static IController WebController { get; private set; }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            WebController = new WebController(ApiRepositoryUseCase.UseSqlite(), CovidRepositoryUseCase.UseInMemory());
            WebController.UpdateAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
