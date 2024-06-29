using NUnit.Framework.Legacy;
using Serilog;

namespace MaxSum.UnitTests
{
    [TestFixture]
    internal class GetAnalyzedLinesTests
    {
        private SumCalculation _sumCalculation = new SumCalculation();
        private LineAnalyzingResultComparer _comparer = new LineAnalyzingResultComparer();

        [Test]
        public void CheckGetAnalyzedLines()
        {
            //Arrange
            List<string> allLines = new List<string> { "1,2,-3", "some text", "4, h, 5" };
            List<LineAnalyzingResult> expectedResult = new List<LineAnalyzingResult>();

            try
            {
                //Act
                expectedResult.Add(new LineAnalyzingResult(0, 0, true));
                expectedResult.Add(new LineAnalyzingResult(1, 0, false));
                expectedResult.Add(new LineAnalyzingResult(2, 0, false));
                List<LineAnalyzingResult> actualResult = _sumCalculation.GetAnalyzedLines(allLines);

                //Assert
                ClassicAssert.IsTrue(expectedResult.SequenceEqual(actualResult, _comparer));
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
            }
        }

        [Test]
        public void CheckGetAnalyzedLines_Empty()
        {
            //Arrange
            List<string> allLines = new List<string>();
            List<LineAnalyzingResult> expectedResult = new List<LineAnalyzingResult>();

            try
            {
                //Act
                List<LineAnalyzingResult> actualResult = _sumCalculation.GetAnalyzedLines(allLines);

                //Assert
                ClassicAssert.IsTrue(expectedResult.SequenceEqual(actualResult, _comparer));
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
            }
        }

        [Test]
        public void CheckGetAnalyzedLines_Null()
        {
            try
            {
                //Act & Assert
                Assert.DoesNotThrow(() =>
                {
                    var result = _sumCalculation.GetAnalyzedLines(null);
                }
                );
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
            }
        }
    }
}
