using MaxSum;
using Serilog;
using Task_3_Maximal_Sum_Of_Elements;

public class Program
{
    public static void Main(string[] args)
    {
        LoggerConfiguration log = new LoggerConfiguration();
        log.WriteTo.Console()
            .WriteTo.File("maxsum.txt", outputTemplate: "{Timestamp:yy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        InputOutput output = new InputOutput();
        ReadFile targetFile = new ReadFile();
        string filePathArg = args.FirstOrDefault(arg => arg.StartsWith("--path="));
        string filePath = output.GetPath(filePathArg);
        //string filePath = output.GetPath();
        targetFile.ReadLines(filePath);
        //Console.ReadKey();
    }
}