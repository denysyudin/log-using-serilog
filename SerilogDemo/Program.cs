using System;  
using Microsoft.Extensions.Configuration;  
using Serilog;  

namespace SerilogDemo  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            // Build configuration from appsettings.json  
            var configuration = new ConfigurationBuilder()  
                .SetBasePath(AppContext.BaseDirectory)  
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)  
                .Build();  

            // Configure Serilog  
            Log.Logger = new LoggerConfiguration()  
                .ReadFrom.Configuration(configuration) // Here is where you bind the configuration  
                .CreateLogger();  

            try  
            {  
                Log.Information("Application Starting");  

                // Example log statements  
                Log.Debug("This is a debug message.");  
                Log.Warning("This is a warning message.");  
                //Log.Error("This is an error message."); // This will go to SQL Server  
                Log.Fatal("This is a critical message."); // This will send an email  

                // Simulate work  
                Console.WriteLine("Press any key to exit...");  
                Console.ReadKey();  
            }  
            catch (Exception ex)  
            {  
                Log.Fatal(ex, "Application terminated unexpectedly");  
            }  
            finally  
            {  
                Log.CloseAndFlush();  
            }  
        }  
    }  
}