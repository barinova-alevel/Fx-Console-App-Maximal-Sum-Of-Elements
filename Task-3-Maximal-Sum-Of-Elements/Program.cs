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

        string filePathArg = args.FirstOrDefault(arg => arg.StartsWith("--path="));

        while (true)
        {
            InputOutput output = new InputOutput();
            ReadFile targetFile = new ReadFile();
            //should be logger or console here? 
            Log.Information("Would you like to read a file? (yes/no): ");
            string userInput = Console.ReadLine().ToLower();

            if (userInput == "no")
            {
                Environment.Exit(1);
            }

            else if (userInput != "yes")
            {
                Log.Information("Invalid input. Please enter 'yes' or 'no'.");
            }

            else if (userInput == "yes")
            {
                string filePath = output.GetPath(filePathArg);
                targetFile.GetAllLines(filePath);
            }
        }
    }
}