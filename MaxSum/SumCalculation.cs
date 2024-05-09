using System.Globalization;
using Serilog;

namespace MaxSum
{
    public class SumCalculation
    {
        List<int> numbersBrokenLines = new List<int>();

        public int GetLineWithMaxSum(List<string> numericLines, List<string> allLines)
        {
            int numberLineWithMaxSum = 1;
            double maxSum = 0;
            Log.Information("Calculating line with max sum.");

            foreach (string line in numericLines)
            {
                double lineSum = LineSumCalculation(line);
                if (lineSum > maxSum)
                {
                    maxSum = lineSum;
                    numberLineWithMaxSum = allLines.IndexOf(line) + 1;
                }
            }

            Log.Information($"Number of the line with max sum is {numberLineWithMaxSum}");
            Log.Information($"The max sum is {maxSum}");
            return numberLineWithMaxSum;
        }

        private double LineSumCalculation(string line)
        {
            double sum = 0.0;
            string[] numbers = line.Split(',');

            foreach (string number in numbers)
            {
                double tempNumber;
                if (double.TryParse(number, NumberStyles.Float, CultureInfo.InvariantCulture, out tempNumber))
                {
                    sum += tempNumber;
                }
                else
                {
                    //Log.Error($"Invalid number format: {number}");
                    break;
                }
            }

            Log.Information($"Sum of elements for '{line}' is {sum}");
            return sum;
        }

        //recheck
        public void ShowNumbersOfNonNumericLines()
        {
            List<int> numbersBroken = numbersBrokenLines;
            Log.Information("Non numeric lines: ");
            foreach (int number in numbersBroken)
            {
                Log.Information($"{number} ");
            }
        }

        public List<string> GetNumericLines(List<string> allLines)
        {
            List<string> numericLines = new List<string>();

            foreach (string line in allLines)
            {
                if (IsNumeric(line))
                {
                    numericLines.Add(line);
                    Log.Information($"'{line}' is numeric.");
                }
                else
                {
                    numbersBrokenLines.Add(allLines.IndexOf(line) + 1);
                    Log.Information($"'{line}' is broken.");
                }
            }
            return numericLines;
        }

        private bool IsNumeric(string line)
        {
            string[] values = line.Split(",");
            foreach (string value in values)
            {
                if (!double.TryParse(value, out double _))
                {
                    return false;
                }
            }
            //bool result = double.TryParse(line, out _);
            return true;
        }
    }
}
