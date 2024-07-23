using Serilog;

namespace MaxSumOfElements.BL
{
    public class FileAnalyzer
    {
        public string FilePath;

        public FileAnalyzer(string filePath)
        {
            this.FilePath = filePath;
        }
        
        public FileAnalyzeResult Analyze()
        {
            int maxIndex = 0;
            int indexOfCurrentLine = 0;
            double maxSum = -1.7976931348623157E+308;
            string line;
            ILineIterator _lineIterator = new LineIterator(FilePath);
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
