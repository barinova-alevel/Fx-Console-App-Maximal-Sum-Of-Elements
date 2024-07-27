using Serilog;
using Microsoft.Extensions.Configuration;
using MaxSumOfElements.UI;
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

        InputOutput inputOutput = new InputOutput();

        string filePathArg = args.FirstOrDefault(arg => arg.StartsWith("--path="));
        inputOutput.Run(filePathArg);

        Console.ReadKey();
    }
}