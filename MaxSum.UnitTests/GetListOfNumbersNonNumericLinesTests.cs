
namespace MaxSum.UnitTests
{
    public class GetListOfNumbersNonNumericLinesTests
    {
        [Test]
        public void GetListOfNumbersNonNumericLines_Positive()
        {
            //Arrange
            SumCalculationResult _sumCalculationResult = new SumCalculationResult(0, 0, new List<int> { 1, 2, 3 });
            var expectedResult = new List<int> { 1, 2, 3 };

            //Act
            var actualResult = _sumCalculationResult
                 .GetListOfNumbersNonNumericLines(_sumCalculationResult);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }

        [Test]
        public void GetListOfNumbersNonNumericLines_NullPassing()
        {
            //Arrange
            SumCalculationResult _sumCalculationResult = new SumCalculationResult(0, 0, new List<int> { 1, 2, 3 });

            //Act&Assert
            Assert.DoesNotThrow(()=> _sumCalculationResult
                 .GetListOfNumbersNonNumericLines(null));
        }
    }
}
