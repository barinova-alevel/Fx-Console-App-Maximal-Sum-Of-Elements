using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace MaxSum
{
    public class SumCalculation
    {
        //How to put filling of broken lines list in a method?
        List<int> numbersBrokenLines = new List<int>();

        public int GetLineWithMaxSum(List<string> numericLines)
        {
            int numberLineWithMaxSum = 1;
            double maxSum = 0;

            foreach (string line in numericLines)
            {
               double lineSum = LineSumCalculation(line);
                if (lineSum > maxSum) 
                {
                    maxSum = lineSum;
                    numberLineWithMaxSum = numericLines.IndexOf(line)+1;
                }
            }
            Log.Information($"The line with max sum is {numberLineWithMaxSum}");
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
                    Log.Error($"Invalid number format: {number}");
                }
            }

            return sum;
        }

        public void ShowNumbersOfNonNumericLines(List<int> numbersBrokenLines)
        {
            Log.Information("Non numeric lines: ");
            foreach (int number in numbersBrokenLines)
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
                }
                else
                {
                    numbersBrokenLines.Add(allLines.IndexOf(line) + 1);
                }
            }
            return numericLines;
        }

        private bool IsNumeric(string line)
        {
            return double.TryParse(line, out _);
        }
    }
}
