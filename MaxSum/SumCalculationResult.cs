using System.Globalization;
using Serilog;

namespace MaxSum
{
    public class SumCalculationResult
    {
        public double MaxSum;
        public List<int> ListOfNonNumericLines;
        public int LineWithMaxSum;
        public IFileWrapper FileWrapperField = new FileWrapper();

        public SumCalculationResult(double maxSum, int lineWithMaxSum, List<int> listOfNonNumericLines)
        {
            MaxSum = maxSum;
            LineWithMaxSum = lineWithMaxSum;
            ListOfNonNumericLines = listOfNonNumericLines;
        }

        public SumCalculationResult AnalizeLines(string path)
        {
            List<string> allLines = FileWrapperField.GetAllLines(path);
            List<LineAnalyzingResult> analizedLines = GetAnalyzedLines(allLines);
            SumCalculationResult result = GetCalculationResult(analizedLines);
            return result;
        }

        public SumCalculationResult GetCalculationResult(List<LineAnalyzingResult> lines)
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
            if (obj != null)
            {
                int result = obj.ListOfNonNumericLines.Count;
                Log.Information($"Number of non numeric lines is {result}");
                return result;
            }
            else
            {
                Log.Information("There is no non numeric lines");
                return 0;
            }
        }

        public List<int> GetListOfNumbersNonNumericLines(SumCalculationResult obj)
        {
            if (obj != null)
            {
                return obj.ListOfNonNumericLines;
            }
            else
            {
                Log.Information("There is no object to get list of non numeric lines.");
                return new List<int> { 0 };
            }
        }

        public double GetMaxSum(SumCalculationResult obj)
        {
            if (obj.LineWithMaxSum != -1)
            {
                Log.Information($"Max sum: {LineWithMaxSum}");
                return LineWithMaxSum;
            }
            else
            {
                return LineWithMaxSum;
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
