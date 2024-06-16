using System.Globalization;
using Serilog;

namespace MaxSum
{
    public class SumCalculation
    {
        private double _maxSum = -1.7976931348623157E+308;
        private List<int> _listOfNonNumericLines = new List<int>();

        public int GetLineWithMaxSum(List<LineAnalyzingResult> lines)
        {
            int numberLineWithMaxSum = 0;
            int counterOfNumericLines = 0;
            try
            {
                foreach (LineAnalyzingResult line in lines)
                {
                    if (line.isNumeric)
                    {
                        double lineSum = line.sumOfElements;
                        if (lineSum > _maxSum)
                        {
                            _maxSum = lineSum;
                            numberLineWithMaxSum = line.indexOfLine + 1;
                        }
                        counterOfNumericLines++;
                    }
                    else
                    {
                        Log.Debug($"Adding line {line.indexOfLine + 1} to list of non numeric");
                        _listOfNonNumericLines.Add(line.indexOfLine + 1);
                    }
                }

                if (counterOfNumericLines == 0)
                {
                    throw new AllLinesNonNumericException("All lines are non numeric");
                }
                else
                {
                    Log.Information($"Line with max sum is {numberLineWithMaxSum}");
                    return numberLineWithMaxSum;
                }
            } 
            
            catch (AllLinesNonNumericException ex)
            {
                Log.Information($"There is no lines to calculate max sum {ex.Message}");
                return -1;
            }
        }

        public List<LineAnalyzingResult> GetAnalyzedLines(List<string> allLines)
        {
            List<LineAnalyzingResult> analyzedLines = new List<LineAnalyzingResult>();
            int lineIndex = 0;

            try
            {
                if ((allLines != null) && (allLines.Count > 0))
                {
                    foreach (string line in allLines)
                    {
                        bool isNumbers = IsNumeric(line);
                        double sum = 0;
                        Log.Debug($"Line {lineIndex + 1}: {line}");

                        if (isNumbers)
                        {
                            sum = LineSumCalculation(line);
                            Log.Debug($"Line {lineIndex + 1} is numeric, its sum: {sum}");
                        }

                        analyzedLines.Add(new LineAnalyzingResult(lineIndex, sum, isNumbers));
                        lineIndex++;
                    }
                    return analyzedLines;
                }
                else
                {
                    Log.Information("Max sum can't be calculated for an empty or not existed file.");
                    Console.WriteLine("Press any key to close the program...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    return analyzedLines;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurs while analyzing lines: {ex.Message}, {ex.StackTrace}");
                throw ex;
            }
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

        public double GetMaxSum(int lineWithMaxSum)
        {
                if (lineWithMaxSum != -1)
                {
                    Log.Information($"Max sum: {_maxSum}");
                    return _maxSum;
                }
                else
                {
                return _maxSum;
                }
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
