public class Program
{
    static void Main(string[] args)
    {
        //string filePathArg = @"C:\Temp\test.txt";
        string filePathArg = args.FirstOrDefault(arg => arg.StartsWith("--path="));

        if (string.IsNullOrEmpty(filePathArg))
        {
            //add logger instead of console here
            //provide a possibility to get a path again
            Console.WriteLine("Usage: MyProgram.exe --path=\"C:\\path\\to\\your\\file.txt\"");
            return;
        }

        string filePath = Path.GetFileName(filePathArg);

        if (File.Exists(filePath))
        {
            Console.WriteLine($"The file at '{filePath}' exists.");
        }
        else
        {
            Console.WriteLine($"The file at '{filePath}' does not exist.");
        }
        //string filePathFromConsole = GetPath();
        //Console.WriteLine(LineCounter(filePathFromConsole));
        //ReadLines(filePathFromConsole);
        Console.ReadKey();
    }

    public static void ReadLines(string filePath)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            int maxSum = int.MinValue;
            string lineWithMaxSum = "";
            int lineNumber = 0;
            int maxSumLineNumber = 0;
            bool isLineBroken = false;

            foreach (string line in lines)
            {
                lineNumber++;
                string[] parts = line.Split(',');

                int sum = 0;

                foreach (string part in parts)
                {
                    if (!int.TryParse(part, out int number))
                    {
                        isLineBroken = true;
                        break;
                    }
                    sum += number;
                }

                if (isLineBroken)
                {
                    //logger instead of console
                    Console.WriteLine($"Line {lineNumber} is broken (contains non-numeric elements).");
                }
                else
                {
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        lineWithMaxSum = line;
                        maxSumLineNumber = lineNumber;
                    }
                }
            }
            if (!string.IsNullOrEmpty(lineWithMaxSum))
            {
                //logger
                Console.WriteLine($"Line with the biggest sum: {lineWithMaxSum}");
                Console.WriteLine($"Biggest sum: {maxSum}");
                Console.WriteLine($"Line number with biggest sum: {maxSumLineNumber}");
            }
            else
            {
                //logger
                Console.WriteLine("No valid lines with sums were found.");
            }
        }

        else
        {
            //logger
            Console.WriteLine("File does not exist.");
        }
    }

    static public int LineCounter(string filePath)
    {
        int numberOfLines = 0;

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.ReadLine() != null)
                {
                    numberOfLines++;
                }
            }
        }
        catch (Exception ex)
        {
            //logger
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return numberOfLines;
    }

    static string GetPath()
    {
        //logger
        Console.WriteLine("Enter Path");
        string filePath = @"" + Console.ReadLine();
        return filePath;
    }
}