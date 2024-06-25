using System;
using NUnit.Framework.Legacy;

namespace MaxSum.UnitTests
{
    [TestFixture]
    internal class GetAnalyzedLinesTests
    {
        private SumCalculation sumCalculation = new SumCalculation();
        private LineAnalyzingResult _lineAnalyzingResult;
        private LineAnalyzingResultComparer _comparer;

        [SetUp]
        public void SetUp()
        {
            _lineAnalyzingResult = new LineAnalyzingResult(0, 0, true);
            _comparer = new LineAnalyzingResultComparer();
        }

        //[Test]
        //public void Convert_WhenCalled_ShouldReturnListOfCustomType()
        //{
        //    // Arrange
        //    var input = new List<string> { "one", "two", "three" };
        //    var expectedOutput = new List<CustomType>
        //{
        //    new CustomType { Value = "one" },
        //    new CustomType { Value = "two" },
        //    new CustomType { Value = "three" }
        //};

        //    // Act
        //    var result = _converter.Convert(input);

        //    // Assert
        //    CollectionAssert.AreEqual(expectedOutput, result, _comparer);
        //}

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
        public void CheckGetAnalyzedLines()
        {
            //Arrange
            List<string> allLines = new List<string> { "1,2,-3", "some text", "4, h, 5" };
            List<LineAnalyzingResult> actualResult;
            List<LineAnalyzingResult> expectedResult = new List<LineAnalyzingResult>();
            expectedResult.Add(new LineAnalyzingResult(0, 0, true));
            expectedResult.Add(new LineAnalyzingResult(1, 0, false));
            expectedResult.Add(new LineAnalyzingResult(2, 0, false));

            //Act
            actualResult = sumCalculation.GetAnalyzedLines(allLines);

            //Assert
            CollectionAssert.AreEqual(actualResult, expectedResult, "The lists are not equal");
        }

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
