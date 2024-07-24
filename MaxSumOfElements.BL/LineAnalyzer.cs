using Serilog;
using System.Globalization;

namespace MaxSumOfElements.BL
{
    public class LineAnalyzer : ILineAnalyzer
    {
        public LineAnalyzeResult AnalyzeLine(string line, int lineIndex)
        {
            if ((line != null) && (lineIndex != null))
            {
                double _lineSum = 0;
                Log.Information($"Reading line {line}.");
                bool isValid = IsNumeric(line);

                if (isValid)
                {
                    _lineSum = LineSumCalculation(line);
                }
                else
                {
                    Log.Information($"Line {line} is non numeric");
                }

                LineAnalyzeResult lineAnalyzeResult = new LineAnalyzeResult(isValid, _lineSum, lineIndex);
                return lineAnalyzeResult;
            }
            return null;
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
                    Log.Debug($"Invalid number format: {number}");
                    break;
                }
            }
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
