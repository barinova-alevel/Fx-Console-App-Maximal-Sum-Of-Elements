using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSum.UnitTests
{
    [TestFixture]
    public class GetLineWithMaxSumTests
    {
        [Test]
        public void GetLine()
        {
            //Arrange
            List<LineAnalyzingResult> list = new List<LineAnalyzingResult>
            { 
                new LineAnalyzingResult(0,0,true), 
                new LineAnalyzingResult(1,3,true),
                new LineAnalyzingResult(2,1000,true),
                new LineAnalyzingResult(3,5000,false) 
            };
            SumCalculation sumCalculation = new SumCalculation();

            //Act
            int result = sumCalculation.GetLineWithMaxSum(list);

            //Assert
            Assert.That(result, Is.EqualTo(3));
        }
        // play with true/false
        //play with negative sum
        //not ordered number of lines, e.g. 3,4,1
        //pass empty list
        //force exception
        //pass null
    }
}
