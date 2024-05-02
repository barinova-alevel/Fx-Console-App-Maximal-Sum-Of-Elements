using System.Text;
using Task_3_Maximal_Sum_Of_Elements;
namespace MaxSum.UnitTests
{
    [TestFixture, Description("Tests related to the file path")]

    public class FilePathTests
    {
        InputOutput inputOutput = new InputOutput();
        [SetUp]
        protected void SetUp()
        {
            string path = "C:\\Temp\\test.txt";

            try
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                //logger
                Console.WriteLine(ex.ToString());
            }
        }
       
        //do i have to add firstly the file in the test purposes? -> add and then remove the file with test data
        // https://docs.nunit.org/articles/nunit/writing-tests/attributes/setupfixture.html 
        [TestCase("--path = 'C:\\Temp\\test.txt'", "C:\\Temp\\test.txt"), Description ("Valid file path test")]
        [TestCase("--path = 'C:\\Temp\\test.txt'","")] //add relative path
        [TestCase("--path = 'C:\\Temp\\test.txt'","")] //path with one dash
        [TestCase("--path = 'C:\\Temp\\test.txt'","")] //path with forward dashes
        [TestCase("--path = 'C:\\Temp\\test.txt'","")] //file has not existed
        public void CheckGetPath(string providedFilePathArgument, string expected)
        {
            //Arrange
            string result;

            //Act

            result = inputOutput.GetPath(providedFilePathArgument);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
        [TearDown]
        public void TearDown()
        {
            //dispose objects
        }
    }
}