using Serilog;
using Microsoft.Extensions.Configuration;
using MaxSumOfElements.BL;
public class Program
{
   public static void Main(string[] args)
    {
        IConfigurationRoot builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder)
            .CreateLogger();
        Log.Logger.Information("start");

        FileAnalyzer fileAnalyzer = new FileAnalyzer();
        fileAnalyzer.Analyze("");

        Console.ReadKey();
    }
}