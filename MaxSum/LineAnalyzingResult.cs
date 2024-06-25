using System.Diagnostics.CodeAnalysis;

namespace MaxSum
{
    public class LineAnalyzingResult
    {
        public int IndexOfLine;
        public double SumOfElements;
        public bool IsNumeric;

        public LineAnalyzingResult(int lineIndex, double sum, bool numericLine)
        {
            IndexOfLine = lineIndex;
            SumOfElements = sum;
            IsNumeric = numericLine;
        }
    }
}
