using System.Linq.Expressions;
using Serilog;

namespace MaxSum
{
    public class ReadFile : IReadFile
    {
        public void ReadLines(string filePath)
        {
            try
            {
                Log.Information("Reading the lines in {filePath}", filePath);
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
                        Log.Debug("Line {lineNumber}: {parts}", lineNumber, parts);
                        int sum = 0;

                        foreach (string part in parts)
                        {
                            if (!int.TryParse(part, out int number))
                            {
                                isLineBroken = true;
                                //Log.Debug("Line {lineNumber} is broken (contains non-numeric elements).", lineNumber);
                                break;
                            }
                            sum += number;
                        }

                        if (isLineBroken)
                        {
                            Log.Debug("Line {lineNumber} is broken (contains non-numeric elements).", lineNumber);
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
                        Log.Information($"Line with the biggest sum: {lineWithMaxSum}");
                        Log.Information($"Biggest sum: {maxSum}");
                        Log.Information($"Line number with biggest sum: {maxSumLineNumber}");
                    }
                    else
                    {
                        Log.Information($"No valid lines with sums were found.");
                    }
                }

                else
                {
                    Log.Information("File does not exist.");
                }
            }
            catch (Exception e)
            {
                Log.Error("Error occurred: {}", e.Message, e);
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
                Log.Debug($"An error occurred: {ex.Message}");
            }
            return numberOfLines;
        }
    }
}
