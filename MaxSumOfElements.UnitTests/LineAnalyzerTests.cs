using MaxSumOfElements.BL;
using NUnit.Framework;

namespace MaxSumOfElements.UnitTests
{
    [TestFixture]
    public class LineAnalyzerTests
    {
        LineAnalyzer lineAnalyzer = new LineAnalyzer();

        [Test]
        public void AnalyzeLyne_ValidArguments()
        {
            //Arrange
            string line = "0, 5";
            int lineIndex = 0;
            LineAnalyzeResult expectedResult = new LineAnalyzeResult(true, 5, 0);

            //Act
            LineAnalyzeResult actualResult = lineAnalyzer.AnalyzeLine(line, lineIndex);

            //Assert
            Assert.That(actualResult.IsValid, Is.EqualTo(expectedResult.IsValid));
            Assert.That(actualResult.LineSum, Is.EqualTo(expectedResult.LineSum));
            Assert.That(actualResult.LineIndex, Is.EqualTo(expectedResult.LineIndex));
        }

        [Test]
        public void AnalyzeLyne_EmptyLinePssing()
        {
            //Arrange
            string line = "";
            int lineIndex = 1;
            LineAnalyzeResult expectedResult = new LineAnalyzeResult(false, 0, 1);

            //Act
            LineAnalyzeResult actualResult = lineAnalyzer.AnalyzeLine(line, lineIndex);

            //Assert
            Assert.That(actualResult.IsValid, Is.EqualTo(expectedResult.IsValid));
            Assert.That(actualResult.LineSum, Is.EqualTo(expectedResult.LineSum));
            Assert.That(actualResult.LineIndex, Is.EqualTo(expectedResult.LineIndex));
        }

        [Test]
        public void AnalyzeLyne_NonNumericLine()
        {
            //Arrange
            string line = "Non numeric line, 123, 12";
            int lineIndex = 2;
            LineAnalyzeResult expectedResult = new LineAnalyzeResult(false, 0, 2);

            //Act
            LineAnalyzeResult actualResult = lineAnalyzer.AnalyzeLine(line, lineIndex);

            //Assert
            Assert.That(actualResult.IsValid, Is.EqualTo(expectedResult.IsValid));
            Assert.That(actualResult.LineSum, Is.EqualTo(expectedResult.LineSum));
            Assert.That(actualResult.LineIndex, Is.EqualTo(expectedResult.LineIndex));
        }

        [Test]
        public void AnalyzeLyne_LineWithSpecSymbols()
        {
            //Arrange
            string line = "#, 123, 12, *";
            int lineIndex = 3;
            LineAnalyzeResult expectedResult = new LineAnalyzeResult(false, 0, 3);

            //Act
            LineAnalyzeResult actualResult = lineAnalyzer.AnalyzeLine(line, lineIndex);

            //Assert
            Assert.That(actualResult.IsValid, Is.EqualTo(expectedResult.IsValid));
            Assert.That(actualResult.LineSum, Is.EqualTo(expectedResult.LineSum));
            Assert.That(actualResult.LineIndex, Is.EqualTo(expectedResult.LineIndex));
        }

        [Test]
        public void AnalyzeLyne_LineSumCalculation()
        {
            //Arrange
            string line = "1, 10, 10";
            int lineIndex = 4;
            LineAnalyzeResult expectedResult = new LineAnalyzeResult(true, 21, 4);

            //Act
            LineAnalyzeResult actualResult = lineAnalyzer.AnalyzeLine(line, lineIndex);

            //Assert
            Assert.That(actualResult.IsValid, Is.EqualTo(expectedResult.IsValid));
            Assert.That(actualResult.LineSum, Is.EqualTo(expectedResult.LineSum));
        }

        [Test]
        public void AnalyzeLyne_LineSumForFloatingNumber()
        {
            //Arrange
            string line = "0.1234, 1.2345, 198.6425";
            int lineIndex = 5;
            LineAnalyzeResult expectedResult = new LineAnalyzeResult(true, 200.0004, 5);

            //Act
            LineAnalyzeResult actualResult = lineAnalyzer.AnalyzeLine(line, lineIndex);

            //Assert
            Assert.That(actualResult.IsValid, Is.EqualTo(expectedResult.IsValid));
            Assert.That(actualResult.LineSum, Is.EqualTo(expectedResult.LineSum));
        }

        [Test]
        public void AnalyzeLyne_LineSumForNegativeNumber()
        {
            //Arrange
            string line = "10, 7, -30";
            int lineIndex = 6;
            LineAnalyzeResult expectedResult = new LineAnalyzeResult(true, -13, 6);

            //Act
            LineAnalyzeResult actualResult = lineAnalyzer.AnalyzeLine(line, lineIndex);

            //Assert
            Assert.That(actualResult.IsValid, Is.EqualTo(expectedResult.IsValid));
            Assert.That(actualResult.LineSum, Is.EqualTo(expectedResult.LineSum));
        }

        [Test]
        public void AnalyzeLine_NullPassing()
        {
            //Act & Assert
            Assert.DoesNotThrow(() => lineAnalyzer.AnalyzeLine(null, 0));
        }
    }
}
