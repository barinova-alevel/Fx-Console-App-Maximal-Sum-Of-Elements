using Task_3_Maximal_Sum_Of_Elements;
namespace MaxSum.UnitTests
{
    [TestFixture, Description("File path tests")]
    public class GetPathTests
    {
        InputOutput inputOutput = new InputOutput();

        [TestCase("--path=\"C:\\Temp\\UnitTests\\test.txt\"", "C:\\Temp\\UnitTests\\test.txt")] //valid file path
        [TestCase("--path=\"C:\\\\Temp\\\\UnitTests\\\\test.txt\"", "C:\\\\Temp\\\\UnitTests\\\\test.txt")] //four slashes test
        [TestCase("--path=\"C:\\\\Temp\\\\UnitTests\\\\Temp1\\\\test.txt\"", "C:\\\\Temp\\\\UnitTests\\\\Temp1\\\\test.txt")] //more than one folder level
        [TestCase("--path=\"C:/Temp/UnitTests/test.txt\"", "C:/Temp/UnitTests/test.txt")] //path with forward slash
        [TestCase("--path=\"C://Temp//UnitTests//test.txt\"", "C://Temp//UnitTests//test.txt")] //path with forward slashes
        [TestCase("--path=\"C:\\Temp\\UnitTests\\test.txt\"", "C:\\Temp\\UnitTests\\test.txt")] //path with backward slash
        [TestCase("--path=\"C:\\Temp\\UnitTests\\notExistedFile.txt\"", "C:\\Temp\\UnitTests\\notExistedFile.txt")] //file has not existed
        public void GetPath_Positive(string providedFilePathArgument, string expected)
        {
            //Arrange
            string result;

            //Act
            result = inputOutput.GetPath(providedFilePathArgument);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("--path=\"null\"")] //path is null
        [TestCase("123:/folder")] //not correct format path
        public void GetPath_Negative(string providedFilePathArgument)
        {
            //Act & Assert
            Assert.DoesNotThrow(() => inputOutput.GetPath(providedFilePathArgument));
        }
    }
}