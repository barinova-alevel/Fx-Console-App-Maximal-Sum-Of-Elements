
namespace MaxSum
{
    public class AllLinesNonNumericException : Exception
    {
        public AllLinesNonNumericException() { }

        public AllLinesNonNumericException(string message)
            : base(message)
        {
        }

        public AllLinesNonNumericException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
