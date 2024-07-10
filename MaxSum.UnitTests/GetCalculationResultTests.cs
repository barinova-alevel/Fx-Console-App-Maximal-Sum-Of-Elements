using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace MaxSum.UnitTests
{
    [TestFixture]
    public class GetCalculationResultTests
    {
        [Test]
        public void GetCalculationResult_Positive()
        {
            //Arrange
            List<LineAnalyzingResult> lineAnalizingResult = new List<LineAnalyzingResult>
            { 
                new LineAnalyzingResult(0,0,true), 
                new LineAnalyzingResult(1,3,true),
                new LineAnalyzingResult(2,1000,true),
                new LineAnalyzingResult(3,5000,false) 
            };
            SumCalculationResult sumCalculation = new SumCalculationResult(0,0, new List<int>());

            //Act
            SumCalculationResult sumCalculationResult = sumCalculation.GetCalculationResult(lineAnalizingResult);

            //Assert
            //CollectionAssert.AreEqual(lineAnalizingResult,)
        }
        // play with true/false
        //play with negative sum
        //not ordered number of lines, e.g. 3,4,1
        //pass empty list
        //force exception
        //pass null
        //recheck tests on exceptions то можна ж за допомогою if перевірити і обробити цю ситуацію.
        

    }
}
