
namespace MaxSumOfElements.BL
{
    public class LineAnalyzeResult
    {
        public bool IsValid;
        public double LineSum;
        public double Max;

        public LineAnalyzeResult(bool isValid, double lineSum, double max)
        {
            IsValid = isValid;
            LineSum = lineSum;
            Max = max;
        }
    }
}
