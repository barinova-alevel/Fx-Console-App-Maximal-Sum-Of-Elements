using MaxSumOfElements.BL;
using NSubstitute;
using NUnit.Framework;

namespace MaxSumOfElements.UnitTests
{
    [TestFixture]
    public class FileAnalyzerTests
    {
        [Test]
        public void Analyze_InitTest()
        {
            //Arrange
            string filePath = "C:\\Temp\\testPath.txt";
            FileAnalyzer fileAnalyzer = new FileAnalyzer(filePath);
            List<int> expectedListOfNonNumericLines = new List<int>();
            expectedListOfNonNumericLines.Add(2);

            var expected = new FileAnalyzeResult(1, expectedListOfNonNumericLines);

            //Act
            ILineIterator mockLineIterator = Substitute.For<ILineIterator>();
            mockLineIterator.GetNextLine().Returns("1", "10", "line2", (string)null);
            var actual = fileAnalyzer.Analyze(mockLineIterator);

            //Assert
            Assert.That(actual.IndexOfLineWithMaxSum, Is.EqualTo(expected.IndexOfLineWithMaxSum));
            Assert.That(actual.NonNumericLines, Is.EqualTo(expected.NonNumericLines));
        }

        [Test]
        public void Analyze_MaxIndexForAllLinesNonNumeric()
        {
            //Arrange
            string filePath = "C:\\Temp\\testPath.txt";
            FileAnalyzer fileAnalyzer = new FileAnalyzer(filePath);
            List<int> expectedListOfNonNumericLines = new List<int>();
            expectedListOfNonNumericLines.Add(0);
            expectedListOfNonNumericLines.Add(1);
            expectedListOfNonNumericLines.Add(2);
            expectedListOfNonNumericLines.Add(3);
            expectedListOfNonNumericLines.Add(4);

            var expected = new FileAnalyzeResult(0, expectedListOfNonNumericLines);

            //Act
            ILineIterator mockLineIterator = Substitute.For<ILineIterator>();
            mockLineIterator.GetNextLine().Returns("1a", "10d", "line,3", "*", "line5", (string)null);
            var actual = fileAnalyzer.Analyze(mockLineIterator);

            //Assert
            Assert.That(actual.IndexOfLineWithMaxSum, Is.EqualTo(expected.IndexOfLineWithMaxSum));
            Assert.That(actual.NonNumericLines, Is.EqualTo(expected.NonNumericLines));
        }

        [Test]
        public void Analyze_MaxIndexForAllLinesNumeric()
        {
            //Arrange
            string filePath = "C:\\Temp\\testPath.txt";
            FileAnalyzer fileAnalyzer = new FileAnalyzer(filePath);
            List<int> expectedListOfNonNumericLines = new List<int>();

            var expected = new FileAnalyzeResult(1, expectedListOfNonNumericLines);

            //Act
            ILineIterator mockLineIterator = Substitute.For<ILineIterator>();
            mockLineIterator.GetNextLine().Returns("1", "10", "3.9", "5", (string)null);
            var actual = fileAnalyzer.Analyze(mockLineIterator);

            //Assert
            Assert.That(actual.IndexOfLineWithMaxSum, Is.EqualTo(expected.IndexOfLineWithMaxSum));
            Assert.That(actual.NonNumericLines, Is.EqualTo(expected.NonNumericLines));
        }

        [Test]
        public void Analyze_NullPassing()
        {
            //Arrange
            string filePath = "C:\\Temp\\testPath.txt";
            FileAnalyzer fileAnalyzer = new FileAnalyzer(filePath);

            //Act & Assert
            Assert.DoesNotThrow(() => fileAnalyzer.Analyze(null));
        }
    }
}
