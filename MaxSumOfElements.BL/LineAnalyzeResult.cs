
namespace MaxSumOfElements.BL
{
    public class LineAnalyzeResult
    {
        public bool IsValid;
        public double LineSum;
        public int LineIndex;

        public LineAnalyzeResult(bool isValid, double lineSum, int lineIndex)
        {
            IsValid = isValid;
            LineSum = lineSum;
            LineIndex = lineIndex;
        }
    }
}
