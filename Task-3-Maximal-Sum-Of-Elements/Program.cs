using MaxSum;
using Microsoft.Extensions.Configuration;
using Serilog;
using Task_3_Maximal_Sum_Of_Elements;

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


        InputOutput output = new InputOutput();
        ReadFile targetFile = new ReadFile();
        string filePathArg = args.FirstOrDefault(arg => arg.StartsWith("--path="));
        string filePath = output.GetPath(filePathArg);
        //string filePath = output.GetPath();
        targetFile.ReadLines(filePath);
        Console.ReadKey();
    }
}