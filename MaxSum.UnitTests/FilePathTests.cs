using Task_3_Maximal_Sum_Of_Elements;

namespace MaxSum.UnitTests
{
    public class FilePathTests
    {
        InputOutput inputOutput = new InputOutput();

        //do i have to add firstly the file in the test purposes?
        //add test case name or description 
        [TestCase("--path = 'C:\\Temp\\test.txt'", "C:\\Temp\\test.txt")]
        public void CheckGetPath(string providedFilePathArgument, string expected)
        {
            //Arrange
            string result;

            //Act
            result = inputOutput.GetPath(providedFilePathArgument);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}