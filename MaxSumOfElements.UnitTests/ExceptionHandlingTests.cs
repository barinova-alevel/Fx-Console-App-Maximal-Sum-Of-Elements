using MaxSumOfElements.BL;
using MaxSumOfElements.Exceptions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace MaxSumOfElements.UnitTests
{
    [TestFixture]
    public class ExceptionHandlingTests
    {
        [Test]
        public void AllLinesNonNumericTest()
        {
            //Arrange
            string filePath = "C:\\Temp\\testPath.txt";
            FileAnalyzer fileAnalyzer = new FileAnalyzer(filePath);
            List<int> expectedListOfNonNumericLines = new List<int>();
            expectedListOfNonNumericLines.Add(0);
            expectedListOfNonNumericLines.Add(1);
            expectedListOfNonNumericLines.Add(2);
            expectedListOfNonNumericLines.Add(3);

            var expected = new FileAnalyzeResult(-1, expectedListOfNonNumericLines);

            //Act
            ILineIterator mockLineIterator = Substitute.For<ILineIterator>();
            mockLineIterator.GetNextLine().Returns("all", "lines", "non", "numeric", (string)null);
            var actual = fileAnalyzer.Analyze(mockLineIterator);

            //Assert
            Assert.That(actual.IndexOfLineWithMaxSum, Is.EqualTo(expected.IndexOfLineWithMaxSum));
            Assert.That(actual.NonNumericLines, Is.EqualTo(expected.NonNumericLines));
        }

        [Test]
        public void EmptyFileTest()
        {
            //Arrange
            string filePath = "C:\\Temp\\testPath.txt";
            FileAnalyzer fileAnalyzer = new FileAnalyzer(filePath);
            List<int> expectedListOfNonNumericLines = new List<int>();

            var expected = new FileAnalyzeResult(-1, expectedListOfNonNumericLines);

            //Act
            ILineIterator mockLineIterator = Substitute.For<ILineIterator>();
            mockLineIterator.GetNextLine().ReturnsNull();
            var actual = fileAnalyzer.Analyze(mockLineIterator);

            //Assert
            Assert.That(actual.IndexOfLineWithMaxSum, Is.EqualTo(expected.IndexOfLineWithMaxSum));
            Assert.That(actual.NonNumericLines, Is.EqualTo(expected.NonNumericLines));
        }
    }
}
