using System;

namespace MaxSumOfElements.BL
{
    public class FileAnalyzer
    {
        int minIndex = 0;
        int maxIndex = 0;
        public string FilePath;

        ILineIterator _lineIterator = new LineIterator();
        ILineAnalyzer _lineAnalyzer = new LineAnalyzer();

        public FileAnalyzer(string filePath)
        {
            this.FilePath = filePath;
        }

        public FileAnalyzeResult Analyze() 
        { 
            return new FileAnalyzeResult(0,0, Array.Empty<int>());
        }
    }
}
