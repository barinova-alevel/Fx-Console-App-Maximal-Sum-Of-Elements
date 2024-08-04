using Serilog;

namespace MaxSumOfElements.BL
{
    public class FileAnalyzer
    {
        public string _filePath { get; }

        public FileAnalyzer(string filePath)
        {
            this._filePath = filePath;
        }
        public ILineIterator GetIterator()
        {
            ILineIterator lineIterator = new LineIterator(_filePath);
            return lineIterator;
        }


        public FileAnalyzeResult Analyze(ILineIterator lineIterator)
        {
            int maxIndex = 0;
            int indexOfCurrentLine = 0;
            double? maxSum = null;
            string line;
            ILineAnalyzer _lineAnalyzer = new LineAnalyzer();
            List<int> invalidLines = new List<int>();

            if (lineIterator != null)
            {
                do
                {
                    line = lineIterator.GetNextLine();
                    LineAnalyzeResult lineResult = _lineAnalyzer.AnalyzeLine(line, indexOfCurrentLine);
                    if (lineResult != null)
                    {
                        if (lineResult.IsValid)
                        {
                            if (maxSum == null)
                            {
                                maxSum = lineResult.LineSum;
                                maxIndex = lineResult.LineIndex;
                            }
                            else if (lineResult.LineSum > maxSum)
                            {
                                maxSum = lineResult.LineSum;
                                maxIndex = lineResult.LineIndex;
                            }
                        }
                        else
                        {
                            Log.Information($"Adding line number {lineResult.LineIndex + 1} to non numeric.");
                            invalidLines.Add(lineResult.LineIndex);
                        }
                        indexOfCurrentLine++;
                    }
                }
                while (line != null);
            }
            Log.Information($"Number of line with max sum: {(maxIndex + 1)}");
            return new FileAnalyzeResult(maxIndex, invalidLines);
        }
    }
}
