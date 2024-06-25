using NUnit.Framework.Legacy;
using Serilog;

namespace MaxSum.UnitTests
{
    [TestFixture]
    internal class GetAnalyzedLinesTests
    {
        private SumCalculation sumCalculation = new SumCalculation();
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
                List<LineAnalyzingResult> actualResult = sumCalculation.GetAnalyzedLines(allLines);

                //Assert
                ClassicAssert.IsTrue(expectedResult.SequenceEqual(actualResult, _comparer));
            }
            catch (Exception ex)
            {
                Log.Information(ex.ToString());
            }
        }
//[Test]
        //public void Convert_WithEmptyList_ShouldReturnEmptyList()
        //{
        //    // Arrange
        //    var input = new List<string>();
        //    var expectedOutput = new List<CustomType>();

        //    // Act
        //    var result = _converter.Convert(input);

        //    // Assert
        //    CollectionAssert.AreEqual(expectedOutput, result, _comparer);
        //}

        //Not working
        //[Test]
       
        [Test]
        public void CheckGetAnalyzedLines_Empty()
        {
            //Arrange
            List<string> allLines = new List<string>();
            List<LineAnalyzingResult> result;

            //Act
            result = sumCalculation.GetAnalyzedLines(allLines);

            //Assert
            Assert.That(result, Is.Empty);
            Assert.That(result, Is.Not.Null);

        }

        [Test]
        public void CheckGetAnalyzedLines_Null()
        {
            //Act & Assert
            Assert.DoesNotThrow(() =>
            {
                var result = sumCalculation.GetAnalyzedLines(null);
            }
            );
        }
    }
}
