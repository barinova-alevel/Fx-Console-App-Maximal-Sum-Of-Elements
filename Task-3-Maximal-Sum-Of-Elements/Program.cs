using MaxSum;
using Task_3_Maximal_Sum_Of_Elements;

public class Program
{
    public static void Main(string[] args)
    {
        InputOutput output = new InputOutput();
        ReadFile targetFile = new ReadFile();
        string filePathArg = args.FirstOrDefault(arg => arg.StartsWith("--path="));
        string filePath = output.GetPath(filePathArg);
        //string filePath = output.GetPath();
        targetFile.ReadLines(filePath);

        Console.ReadKey();
    }
}