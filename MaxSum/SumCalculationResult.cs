using System.Globalization;
using Serilog;

namespace MaxSum
{
    public class SumCalculationResult
    {
        private double _maxSum;
        private List<int> _listOfNonNumericLines;
        private int _lineWithMaxSum;
        FileWrapper _fileWrapper = new FileWrapper();

        public SumCalculationResult(double maxSum, int lineWithMaxSum, List<int> listOfNonNumericLines)
        {
            _maxSum = maxSum;
            _lineWithMaxSum = lineWithMaxSum;
            _listOfNonNumericLines = listOfNonNumericLines;
        }

        public SumCalculationResult AnalizeLines(string path)
        {
            List<string> allLines = _fileWrapper.GetAllLines(path);
            List<LineAnalyzingResult> analizedLines = GetAnalyzedLines(allLines);
            SumCalculationResult result = GetLineWithMaxSum(analizedLines);
            return result;
        }

        private SumCalculationResult GetLineWithMaxSum(List<LineAnalyzingResult> lines)
        {
            int lineWithMaxSum = 0;
            int counterOfNumericLines = 0;
            double maxSum = -1.7976931348623157E+308;
            List<int> listOfNonNumericLines = new List<int>();

            try
            {
                foreach (LineAnalyzingResult line in lines)
                {
                    if (line.IsNumeric)
                    {
                        double lineSum = line.SumOfElements;
                        if (lineSum > maxSum)
                        {
                            maxSum = lineSum;
                            lineWithMaxSum = line.IndexOfLine + 1;
                        }
                        counterOfNumericLines++;
                    }
                    else
                    {
                        Log.Debug($"Adding line {line.IndexOfLine + 1} to list of non numeric.");
                        listOfNonNumericLines.Add(line.IndexOfLine + 1);
                    }
                }

                if (counterOfNumericLines == 0)
                {
                    throw new AllLinesNonNumericException("All lines are non numeric.");
                }
                else
                {
                    Log.Information($"Line with max sum is {lineWithMaxSum}");
                    return new SumCalculationResult(maxSum, lineWithMaxSum, listOfNonNumericLines);
                }
            }

            catch (AllLinesNonNumericException ex)
            {
                Log.Information($"There is no lines to calculate max sum. {ex.Message}");
                return new SumCalculationResult(0, -1, listOfNonNumericLines);
            }
        }

        private List<LineAnalyzingResult> GetAnalyzedLines(List<string> allLines)
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
                }
                else if (allLines == null)
                {
                    throw new ArgumentNullException("Input cannot be null.");
                }
                return analyzedLines;
            }
            catch (ArgumentNullException ex)
            {
                Log.Information($"Max sum can't be calculated for not existed file. {ex.Message}");
                return analyzedLines;
            }
            catch (Exception ex)
            {
                Log.Error($"An error occurs while analyzing lines: {ex.Message}");
                return analyzedLines;
            }
        }

        public int GetNumberOfNonNumericLines(SumCalculationResult obj)
        {
            int result = obj._listOfNonNumericLines.Count;
            Log.Information($"Number of non numeric lines is {result}");
            return result;
        }

        public List<int> GetListOfNumbersNonNumericLines(SumCalculationResult obj)
        {
            return obj._listOfNonNumericLines;
        }

        public double GetMaxSum(SumCalculationResult obj)
        {
            if (obj._lineWithMaxSum != -1)
            {
                Log.Information($"Max sum: {_lineWithMaxSum}");
                return _lineWithMaxSum;
            }
            else
            {
                return _lineWithMaxSum;
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
