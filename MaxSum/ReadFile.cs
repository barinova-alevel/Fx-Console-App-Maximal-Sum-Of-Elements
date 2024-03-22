namespace MaxSum
{
    public class ReadFile : IReadFile
    {
        public void ReadLines(string filePath)
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
    }
}
