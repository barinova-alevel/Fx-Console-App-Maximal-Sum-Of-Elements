using NUnit.Framework.Legacy;

namespace MaxSum.UnitTests
{
    [TestFixture]
    public class GetCalculationResultTests
    {
        private SumCalculationResult _sumCalculation = new SumCalculationResult(0, 0, new List<int> { 1, 2, 3 });

        [Test]
        public void GetCalculationResult_Positive()
        {
            //Arrange
            List<LineAnalyzingResult> lineAnalizingResult = new List<LineAnalyzingResult>
            {
                new LineAnalyzingResult(0,0,true),
                new LineAnalyzingResult(1,3,true),
                new LineAnalyzingResult(2,5,true),
                new LineAnalyzingResult(3,5000,false)
            };
            SumCalculationResult expectedResult = new SumCalculationResult(5, 3, new List<int> { 4 });

            //Act
            SumCalculationResult actualResult = _sumCalculation.GetCalculationResult(lineAnalizingResult);

            //Assert
            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));

        }

        [Test]
        public void GetCalculationResult_AllLinesNumeric()
        {
            //Arrange
            List<LineAnalyzingResult> lineAnalizingResult = new List<LineAnalyzingResult>
            {
                new LineAnalyzingResult(0,0,true),
                new LineAnalyzingResult(1,3,true),
                new LineAnalyzingResult(2,5,true),
                new LineAnalyzingResult(3,5000,true)
            };
            SumCalculationResult expectedResult = new SumCalculationResult(5000, 4, new List<int> { });

            //Act
            SumCalculationResult actualResult = _sumCalculation.GetCalculationResult(lineAnalizingResult);

            //Assert
            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));

        }

        [Test]
        public void GetCalculationResult_AllLinesNonNumeric()
        {
            //Arrange
            List<LineAnalyzingResult> lineAnalizingResult = new List<LineAnalyzingResult>
            {
                new LineAnalyzingResult(0,0,false),
                new LineAnalyzingResult(1,3,false),
                new LineAnalyzingResult(2,5,false),
                new LineAnalyzingResult(3,5000,false)
            };
            SumCalculationResult expectedResult = new SumCalculationResult(0, -1, new List<int> { 1, 2, 3, 4 });

            //Act
            SumCalculationResult actualResult = _sumCalculation.GetCalculationResult(lineAnalizingResult);

            //Assert
            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));
        }

        [Test]
        public void GetCalculationResult_MaxSumIsNegativeNumber()
        {
            //Arrange
            List<LineAnalyzingResult> lineAnalizingResult = new List<LineAnalyzingResult>
            {
                new LineAnalyzingResult(0,0,false),
                new LineAnalyzingResult(1,3,false),
                new LineAnalyzingResult(2,-5,true),
                new LineAnalyzingResult(3,-5000,true)
            };
            SumCalculationResult expectedResult = new SumCalculationResult(-5, 3, new List<int> { 1, 2 });

            //Act
            SumCalculationResult actualResult = _sumCalculation.GetCalculationResult(lineAnalizingResult);

            //Assert
            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
        }

        [Test]
        public void GetCalculationResult_NotOrderedNumberOfLines()
        {
            //Arrange
            List<LineAnalyzingResult> lineAnalizingResult = new List<LineAnalyzingResult>
            {
                new LineAnalyzingResult(0,0,false),
                new LineAnalyzingResult(1,3,false),
                new LineAnalyzingResult(2,5,true),
                new LineAnalyzingResult(3,5000,false)
            };
            SumCalculationResult expectedResult = new SumCalculationResult(5, 3, new List<int> { 2, 4, 1 });

            //Act
            SumCalculationResult actualResult = _sumCalculation.GetCalculationResult(lineAnalizingResult);

            //Assert
            Assert.That(actualResult.ListOfNonNumericLines, Is.EquivalentTo(expectedResult.ListOfNonNumericLines));
        }

        [Test]
        public void GetCalculationResult_PassEmptyList()
        {
            //Arrange
            List<LineAnalyzingResult> lineAnalizingResult = new List<LineAnalyzingResult> { };
            SumCalculationResult expectedResult = new SumCalculationResult(0, -1, new List<int> { });

            //Act
            SumCalculationResult actualResult = _sumCalculation.GetCalculationResult(lineAnalizingResult);

            //Assert
            Assert.That(actualResult.MaxSum, Is.EqualTo(expectedResult.MaxSum));
            Assert.That(actualResult.LineWithMaxSum, Is.EqualTo(expectedResult.LineWithMaxSum));
            Assert.That(actualResult.ListOfNonNumericLines, Is.EqualTo(expectedResult.ListOfNonNumericLines));
        }

        [Test]
        public void GetCalculationResult_NullPassing()
        {
            //Arrange
            List<LineAnalyzingResult> lineAnalizingResult = null;

            //Act & Assert
            ClassicAssert.NotNull(() => _sumCalculation.GetCalculationResult(lineAnalizingResult));
            Assert.DoesNotThrow(() => _sumCalculation.GetCalculationResult(null));
        }

        //Add test for Calculate floating point numbers!!!!
    }
}
