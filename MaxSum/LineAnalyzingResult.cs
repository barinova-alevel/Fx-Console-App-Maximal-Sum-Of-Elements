namespace MaxSum
{
    public class LineAnalyzingResult
    {
        public int indexOfLine;
        public double sumOfElements;
        public bool isNumeric;

        public LineAnalyzingResult(int lineIndex, double sum, bool numericLine)
        {
            indexOfLine = lineIndex;
            sumOfElements = sum;
            isNumeric = numericLine;
        }
        
    }
}
