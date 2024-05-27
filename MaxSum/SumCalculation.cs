using System.Globalization;
using Serilog;

namespace MaxSum
{
    public class SumCalculation
    {
        private double maxSum = 0;
        private List<int> numbersBrokenLines = new List<int>();

        public int GetLineWithMaxSum(List<LineAnalyzingResult> lines)
        {
            //what if all lines broken? numberLineWithMaxSum?
            int numberLineWithMaxSum = 1;

            foreach (LineAnalyzingResult line in lines)
            {
                if (line.isNumeric)
                {
                    double lineSum = line.sumOfElements;
                    if (lineSum > maxSum)
                    {
                        maxSum = lineSum;
                        numberLineWithMaxSum = line.indexOfLine + 1;
                    }
                }
                else
                {
                    numbersBrokenLines.Add(line.indexOfLine + 1);
                }
            }
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

        public List<LineAnalyzingResult> GetAnalyzedLines(List<string> allLines)
        {
            List<LineAnalyzingResult> objectLine = new List<LineAnalyzingResult>();
            int lineIndex = 0;


            foreach (string line in allLines)
            {
                bool isNumbers = IsNumeric(line);
                double sum = 0;
                if (isNumbers)
                {
                    sum = LineSumCalculation(line);
                }

                objectLine.Add(new LineAnalyzingResult(lineIndex, sum, isNumbers));
                lineIndex++;
            }
            return objectLine;
        }

        public int NumberNotNumericLines()
        {
            int result = numbersBrokenLines.Count;
            Log.Information($"Number of broken lines is {result}");
            return result;
        }

        public void ShowNumbersOfNotNumericLines()
        {
            List<int> numbersBroken = numbersBrokenLines;
            string result = String.Join(", ", numbersBroken);
            Log.Information($"Non numeric lines: {result}");
        }

        public List<int> GetListOfNumbersNotNumericLines()
        {
            return numbersBrokenLines;
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
            return true;
        }
    }
}
