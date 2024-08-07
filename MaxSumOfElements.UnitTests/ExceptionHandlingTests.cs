using MaxSumOfElements.BL;
using MaxSumOfElements.Exceptions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
