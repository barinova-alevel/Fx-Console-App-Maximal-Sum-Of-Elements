
namespace MaxSumOfElements.BL
{
    public class FileAnalyzeResult
    {
        public int MinIndex;
        public int MaxIndex;
        public int[] InvalidLines;

        public FileAnalyzeResult(int minIndex, int maxIndex, int[] invalidLines)
        {
            MinIndex = minIndex;
            MaxIndex = maxIndex;   
            InvalidLines = invalidLines;
        }
    }
}
