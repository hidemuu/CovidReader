using CovidReader.Repository.Api.Sql;
using CovidReader.UseCases;
using CovidReader.UseCases.Controllers;
using CovidReader.UseCases.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidReader.WebApi
{
    public class Program
    {
        public static WebAppController WebController { get; private set; }

        public static void Main(string[] args)
        {
            WebController = new WebAppController(ApiServiceUseCase.Create("sql", "sql"), Covid19ServiceUseCase.Create("inmemory", "csv"));
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
