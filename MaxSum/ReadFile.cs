using Serilog;

namespace MaxSum
{
    public class ReadFile : IReadFile
    {
        public List<string> GetAllLines(string filePath)
        {
            List<string> allLines = new List<string>();
            try
            {
                if (!File.Exists(filePath)) 
                {
                    Log.Debug($"File {filePath} does not exist.");
                    return allLines;
                }
                Log.Information($"Reading file from {filePath}");
                string[] linesArray = File.ReadAllLines(filePath);
                allLines.AddRange(linesArray);
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured while reading the file: {ex.Message}");
            }
            return allLines;
        }
        public void ReadLines(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    Log.Information("Reading the lines in {filePath}", filePath);
                    string[] lines = File.ReadAllLines(filePath);
                    double maxSum = double.MinValue;
                    string lineWithMaxSum = "";
                    int lineNumber = 0;
                    int maxSumLineNumber = 0;


                    foreach (string line in lines)
                    {
                        bool isLineBroken = false;
                        lineNumber++;

                        string[] parts = line.Split(',');
                        Log.Debug("Line {lineNumber}: {parts}", lineNumber, parts);
                        double sum = 0;

                        foreach (string part in parts)
                        {
                            if (!double.TryParse(part, out double number))
                            {
                                isLineBroken = true;
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
                        //return lineNumber;
                    }
                    else
                    {
                        Log.Information($"No valid lines with sums were found.");
                        //return -1; //what should i return here?
                    }
                }

                else
                {
                    Log.Information("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                var message = ex.GetType().FullName;
                var messageDetails = ex.Message;
                Log.Error("Error occurred: {message} \n{messageDetails} \n{ex}", message, messageDetails, ex);
            }
        }
    }
}
