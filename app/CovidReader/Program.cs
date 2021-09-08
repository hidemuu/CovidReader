using CovidReader.Api;
using CovidReader.Controllers;
using CovidReader.Infrastructure;
using CovidReader.Repository;
using CovidReader.Repository.Api;
using CovidReader.Repository.Covid;
using CovidReader.Repository.Covid.Csv;
using CovidReader.Repository.Covid.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidReader
{
    class Program
    {
        private static CommandBase _command;

        static void Main(string[] args)
        {
            _command = new ConsoleCommand("sql", "inmemory");

           Console.WriteLine(_command.Help());
            //if (_command.ViewSample())
            //{
            //    WindowHelper.SetForeground("CovidReader");
            //}
            
            while (true)
            {
                Console.WriteLine("コマンドを入力して下さい");
                Console.Write("> ");
                var input = Console.ReadLine() ?? string.Empty;
                var tokens = input.Split(' ');

                if (tokens.Length < 1)
                {
                    Console.WriteLine("コマンドを入力して下さい");
                    continue;
                }

                var command = tokens.First();
                var parameters = tokens.Skip(1);

                if (!_command.IsExist(command))
                {
                    Console.WriteLine($"登録されていないコマンドです: {command}");
                }
                else if (command == "end")
                {
                    break;
                }
                else
                {
                    var task = _command.RunAsync(command, parameters);
                    Task.WaitAll(task);
                    Console.WriteLine(_command.GetResponse());
                }

            }

            Console.WriteLine("アプリケーションを終了します");
            Console.ReadLine();
        }

        
        
    }
}
