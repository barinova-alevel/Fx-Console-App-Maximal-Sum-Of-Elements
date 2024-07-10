using NUnit.Framework.Legacy;

namespace MaxSum.UnitTests
{
    [TestFixture]
    internal class GetAnalyzedLinesTests
    {
        private SumCalculationResult _sumCalculation = new SumCalculationResult(0, 0, new List<int> { 1,2,3});
        private LineAnalyzingResultComparer _comparer = new LineAnalyzingResultComparer();

        [Test]
        public void GetAnalyzedLines_Positive()
        {
            //Arrange
            List<string> allLines = new List<string> { "1,2,-3", "some text", "4, h, 5" };
            List<LineAnalyzingResult> expectedResult = new List<LineAnalyzingResult>();

            //Act
            expectedResult.Add(new LineAnalyzingResult(0, 0, true));
            expectedResult.Add(new LineAnalyzingResult(1, 0, false));
            expectedResult.Add(new LineAnalyzingResult(2, 0, false));
            List<LineAnalyzingResult> actualResult = _sumCalculation.GetAnalyzedLines(allLines);

            //Assert
            ClassicAssert.IsTrue(expectedResult.SequenceEqual(actualResult, _comparer));
        }

        [Test]
        public void GetAnalyzedLines_EmptyList()
        {
            //Arrange
            List<string> allLines = new List<string>();
            List<LineAnalyzingResult> expectedResult = new List<LineAnalyzingResult>();

            //Act
            List<LineAnalyzingResult> actualResult = _sumCalculation.GetAnalyzedLines(allLines);

            //Assert
            ClassicAssert.IsTrue(expectedResult.SequenceEqual(actualResult, _comparer));
        }

        [Test]
        public void GetAnalyzedLines_ListIsNull()
        {
            //Arrange
            List<string> inputList = null;

            //Act & Assert
             Assert.DoesNotThrow(() => _sumCalculation.GetAnalyzedLines(inputList));
        }
    }
}
