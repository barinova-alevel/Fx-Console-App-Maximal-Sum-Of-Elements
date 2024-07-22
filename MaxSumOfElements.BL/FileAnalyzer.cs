using System;

namespace MaxSumOfElements.BL
{
    public class FileAnalyzer
    {
        public List<string> Analyze(string path)
        {
            List<string> result = new List<string>();
            ReadFile rf = new ReadFile();

            rf.ReadLines(path);
            return result;
        }
    }
}
