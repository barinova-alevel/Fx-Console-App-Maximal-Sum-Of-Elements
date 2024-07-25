
namespace MaxSumOfElements.BL
{
    public class FileAnalyzeResult
    {
        public int MaxIndex;
        public List<int> InvalidLines = new List<int>();

        public FileAnalyzeResult(int maxIndex, List<int> invalidLines)
        {
            MaxIndex = maxIndex;   
            InvalidLines = invalidLines;
        }
    }
}
