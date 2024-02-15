using System.Text;
using System;
using System.IO;
public class Program
{
    //Program should find the maximum sum of elements in line from the list of lines.

    //Program will take path to file as input (user can enter path in console application or send as command line interface argument if they exist).

    //Each line of the file contains a number set (number separator is comma, decimal separator is point).

    //Result should be the number of the line with a maximum sum of elements in line.

    //If line contains non numeric elements - line marked as broken.

    //As a separate list, write a number of lines with non numeric elements (“wrong elements”).

    //https://docs.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo?view=net-6.0

    //https://docs.microsoft.com/en-us/dotnet/api/system.globalization.numberformatinfo?view=net-6.0

    // https://docs.microsoft.com/en-us/dotnet/standard/io/

    static void Main(string[] args)
    {
        string filePath = GetPath();
        Console.WriteLine(LineCounter(filePath));
        ReadLines(filePath);
        Console.ReadKey();
    }

    public static void ReadLines(string filePath)
    {
        if (File.Exists(filePath))
        {
            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);
            int maxSum = int.MinValue;
            string lineWithMaxSum = "";
            int lineNumber = 0; // Optional: Track the line number
            int maxSumLineNumber = 0;
            bool isLineBroken = false;

            // Process each line
            foreach (string line in lines)
            {
                lineNumber++;
                // Split the line into parts using space as a separator
                string[] parts = line.Split(',');

                // Convert the parts to integers and sum them
                int sum = 0;
                //isLineBroken = false;

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
                    // Handle the broken line case
                    Console.WriteLine($"Line {lineNumber} is broken (contains non-numeric elements).");
                }
                else
                {

                    // Check if this line has the maximum sum
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        lineWithMaxSum = line;
                        maxSumLineNumber = lineNumber; // Update line number with max sum
                    }
                }
            }
            if (!string.IsNullOrEmpty(lineWithMaxSum))
            {
                Console.WriteLine($"Line with the biggest sum: {lineWithMaxSum}");
                Console.WriteLine($"Biggest sum: {maxSum}");
                Console.WriteLine($"Line number with biggest sum: {maxSumLineNumber}");
            }
            else
            {
                Console.WriteLine("No valid lines with sums were found.");
            }
        }

        else
        {
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
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        return numberOfLines;
    }

    static string GetPath()
    {
        Console.WriteLine("Enter Path");
        string filePath = @"" + Console.ReadLine();
        return filePath;
    }
}
    //Is empty counts as null?
    //What is the line==null  
    //How to prevent entering wrong format path?
    //What is the file extension - txt, xml, xls..? - any
    //txt reads perfectly, xlsx problems encoding - think of cultural info? 
    // What does it mean? send /path/ as command line interface argument if they exist
    //command line interface argument - мається на увазі, що застосунок може бути викликаний з консолі разом з параметром. Наприклад, maxsum.exe --path=folder/file.ext
    //Ось тут базова інформація про аргументи.Можеш сама парсити аргументи або можеш знайти бібілотеку, яка це вміє робити.
