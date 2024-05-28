using System.Globalization;
using Serilog;

namespace MaxSum
{
    public class SumCalculation
    {
        private double _maxSum = 0;
        private List<int> _listOfNonNumericLines = new List<int>();

        public int GetLineWithMaxSum(List<LineAnalyzingResult> lines)
        {
            //what if all lines broken? numberLineWithMaxSum?
            int numberLineWithMaxSum = 1;

            foreach (LineAnalyzingResult line in lines)
            {
                if (line.isNumeric)
                {
                    Log.Information($"Line {line.indexOfLine + 1} is numeric");
                    double lineSum = line.sumOfElements;
                    if (lineSum > _maxSum)
                    {
                        _maxSum = lineSum;
                        numberLineWithMaxSum = line.indexOfLine + 1;
                    }
                }
                else
                {
                    Log.Information($"Line {line.indexOfLine + 1} is non numeric");
                    _listOfNonNumericLines.Add(line.indexOfLine + 1);
                }
            }
            Log.Information($"Line with max sum is {numberLineWithMaxSum}");
            return numberLineWithMaxSum;
        }

        public List<LineAnalyzingResult> GetAnalyzedLines(List<string> allLines)
        {
            List<LineAnalyzingResult> analyzedLines = new List<LineAnalyzingResult>();
            int lineIndex = 0;

            foreach (string line in allLines)
            {
                bool isNumbers = IsNumeric(line);
                double sum = 0;
                if (isNumbers)
                {
                    sum = LineSumCalculation(line);
                    Log.Debug($"Sum of line {lineIndex + 1}: {sum}");
                }

                analyzedLines.Add(new LineAnalyzingResult(lineIndex, sum, isNumbers));
                lineIndex++;
            }
            return analyzedLines;
        }

        public int GetNumberOfNonNumericLines()
        {
            int result = _listOfNonNumericLines.Count;
            Log.Information($"Number of non numeric lines is {result}");
            return result;
        }

        public List<int> GetListOfNumbersNonNumericLines()
        {
            return _listOfNonNumericLines;
        }

        public double GetMaxSum()
        {
            return _maxSum;
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
