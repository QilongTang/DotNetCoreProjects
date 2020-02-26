using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace MyFirstApp
{
    public class Program
    {
        static public string DefaultConnectionString { get; } = @"Server=(localdb)\\mssqllocaldb;Database=SampleData-0B3B0919-C8B3-481C-9833-36C21776A565;Trusted_Connection=True;MultipleActiveResultSets=true";
        static IReadOnlyDictionary<string, string> DefaultConfigurationStrings { get; } = 
        new Dictionary<string, string>()
        {
            ["Profile:UserName"] = Environment.UserName,
            ["AppConfiguration:ConnectionString"] = DefaultConnectionString,
        };

        static public IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddInMemoryCollection(DefaultConfigurationStrings);
            //configurationBuilder.AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            configurationBuilder.AddIniFile("appsetting.ini", true);
            Configuration = configurationBuilder.Build();
            Console.SetWindowSize(Int32.Parse(Configuration["AppConfiguration:MainWindow:Width"]), (Int32.Parse(Configuration["AppConfiguration:MainWindow:Height"])));
            Console.WriteLine($"Hello {Configuration["Profile:UserName"]}");

            Console.WriteLine($"{Configuration["message"]}");
            Console.ReadKey();
        }
    }
}
