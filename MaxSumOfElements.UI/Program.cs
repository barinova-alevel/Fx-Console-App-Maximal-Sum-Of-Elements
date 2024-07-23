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

        string path = "";
        FileAnalyzer fileAnalyzer = new FileAnalyzer(path);
        fileAnalyzer.Analyze();

        Console.ReadKey();
    }
}