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
            IFileWrapper fileWrapper = new FileWrapper();
            InputOutput output = new InputOutput();
            ReadFile targetFile = new ReadFile(fileWrapper);
            SumCalculation sumCalculation = new SumCalculation();

            Console.WriteLine("Would you like to read a file? (yes/no): ");
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
               // List<string> allLines = targetFile.GetAllLines(filePath);
                List<string> allLines = targetFile.GetAllLines("C:\\Temp\\TestAccess.txt");
                //List<string> allLines = targetFile.GetAllLines("C:\\Temp\\Test.txt");
                List<LineAnalyzingResult> analizedLines = sumCalculation.GetAnalyzedLines(allLines);
                int lineWithMaxSum = sumCalculation.GetLineWithMaxSum(analizedLines);
                double maxSum = sumCalculation.GetMaxSum(lineWithMaxSum);
                int numberOfBrokenLines = sumCalculation.GetNumberOfNonNumericLines();
                List<int> listOfNumbersNonNumericLines = sumCalculation.GetListOfNumbersNonNumericLines();

                Log.Information("List of non numeric lines:");
                output.PrintNumbersOfLines(listOfNumbersNonNumericLines);
            }
        }
    }
}