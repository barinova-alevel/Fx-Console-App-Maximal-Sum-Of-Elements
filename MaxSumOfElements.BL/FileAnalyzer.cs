using Serilog;

namespace MaxSumOfElements.BL
{
    public class FileAnalyzer
    {
        private string _filePath;

        public FileAnalyzer(string filePath)
        {
            this._filePath = filePath;
        }
        
        public FileAnalyzeResult Analyze()
        {
            int maxIndex = 0;
            int indexOfCurrentLine = 0;
            double maxSum = -1.7976931348623157E+308;
            string line;
            ILineIterator _lineIterator = new LineIterator(_filePath);
            ILineAnalyzer _lineAnalyzer = new LineAnalyzer();
            List<int> invalidLines = new List<int>();

            do
            {
                line = _lineIterator.GetNextLine();
                LineAnalyzeResult lineResult = _lineAnalyzer.AnalyzeLine(line, indexOfCurrentLine);
                if (lineResult != null)
                {
                    if (lineResult.IsValid)
                    {
                        if (lineResult.LineSum > maxSum)
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

            Log.Information($"Number of line with max sum: {(maxIndex + 1)}");
            return new FileAnalyzeResult(maxIndex, invalidLines);
        }
    }
}
