namespace MaxSum
{
    public class LineAnalyzingResultComparer : IEqualityComparer<LineAnalyzingResult>
    {
        public bool Equals(LineAnalyzingResult? x, LineAnalyzingResult? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
            return ((x.IndexOfLine == y.IndexOfLine)
                && (x.SumOfElements == y.SumOfElements)
                && (x.IsNumeric == y.IsNumeric));
        }

        public int GetHashCode(LineAnalyzingResult obj)
        {
            return ((obj.IndexOfLine == null)
                || (obj.SumOfElements == null)
                || (obj.IsNumeric == null))
                ? 0 : HashCode.Combine(obj.IndexOfLine, obj.SumOfElements, obj.IsNumeric);
        }
    }
}
