using System;
using System.Collections.Generic;
using System.IO;
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
           // SumCalculationResult sumCalculation = new SumCalculation();

            //Act
            //int result = sumCalculation.GetLineWithMaxSum(list);

            //Assert
            //Assert.That(result, Is.EqualTo(3));
        }
        // play with true/false
        //play with negative sum
        //not ordered number of lines, e.g. 3,4,1
        //pass empty list
        //force exception
        //pass null
        //recheck tests on exceptions то можна ж за допомогою if перевірити і обробити цю ситуацію.
        //В твоєму випадку я б зробив FileWrapper полем класу SumCalculation.Тоді при виклику AnalizeLines(path) (новий метод замість GetLineWithMaxSum) всередині буде відбуватись зчитування з файлу і аналіз рядків.Також SumCalculation не повинен зберігати в собі якусь частину результатів аналізу.Якщо він повертає їх як результат метода, то повинен повертати весь аналіз.

    }
}
