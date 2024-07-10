
namespace MaxSum.UnitTests
{
    [TestFixture]
    public class GetNumberOfNonNumericLinesTests
    {
        [Test]
        public void GetNumberOfNonNumericLines_Positive()
        {
            //Arrange
            SumCalculationResult _sumCalculationResult = new SumCalculationResult(1, 1, new List<int> { 2, 3, 7 });

            //Act
            int actualResult = _sumCalculationResult.GetNumberOfNonNumericLines(_sumCalculationResult);

            //Assert
            Assert.That(actualResult, Is.EqualTo(3));
        }

        [Test]
        public void GetNumberOfNonNumericLines_NullPassing()
        {
            //Arrange
            SumCalculationResult _sumCalculationResult = new SumCalculationResult(1, 1, new List<int> { 2, 3, 7 });

            //Act&Assert
            Assert.DoesNotThrow(() => _sumCalculationResult.GetNumberOfNonNumericLines(null));
        }

        [Test]
        public void GetNumberOfNonNumericLines_PassingOfEmptyList()
        {
            //Arrange
            SumCalculationResult _sumCalculationResult = new SumCalculationResult(1, 1, new List<int>());

            //Act
            int actualResult = _sumCalculationResult.GetNumberOfNonNumericLines(_sumCalculationResult);

            //Assert
            Assert.That(actualResult, Is.EqualTo(0));
        }
    }
}
