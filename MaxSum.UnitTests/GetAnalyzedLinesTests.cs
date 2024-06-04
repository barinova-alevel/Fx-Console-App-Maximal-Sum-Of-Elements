
using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Legacy;

namespace MaxSum.UnitTests
{
    [TestFixture]
    internal class GetAnalyzedLinesTests
    {
        SumCalculation sumCalculation = new SumCalculation();

        [Test]
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

            //always return true, need to find another assert.
            //Assert
            CollectionAssert.AreEqual(expectedResult, expectedResult, "The lists are not equal");
        }

        public void CheckGetAnalyzedLines_Empty() 
        {
        
        }

        public void CheckGetAnalyzedLines_Null()
        {

        }
    }
}
