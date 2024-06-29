using System.IO;
using System;
using System.Text;
using Serilog;
using NSubstitute;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace MaxSum.UnitTests
{
    [TestFixture, Description("File tests")]

    public class GetAllLinesTests
    {
        private IFileWrapper _fileWrapper;

        public GetAllLinesTests()
        {
            _fileWrapper = Substitute.For<IFileWrapper>();
        }

        [TestCase(new string[] { "0,0,3", "1,-5,4" }, new string[] { "0,0,3", "1,-5,4" })]
        [TestCase(new string[] { "h,k,3", "1000,-0,4.2" }, new string[] { "h,k,3", "1000,-0,4.2" })]
        public void GetAllLines_GivenInputIsCorrect(string[] returnArgument, string[] expectedArray)
        {
            //Arrange
            var actual = new List<string>(returnArgument);
            var expected = new List<string>(expectedArray);

            //Act         
            _fileWrapper.GetAllLines("C://Temp//UnitTests//test.txt").Returns(actual);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void CheckGetAllLines_NullPassing()
        {
            //Arrange
            FileWrapper readFile = new FileWrapper();
            string path = null;

            //Act&Assert
            Assert.DoesNotThrow(() => readFile.GetAllLines(path));
        }

        [Test]
        public void CheckGetAllLines_EmptyFile()
        {
            //Arrange
            FileWrapper readFile = new FileWrapper();
            string path = "C://Temp//UnitTests//test.txt";

            //Act
            CreateFile(path, String.Empty);

            //Assert
            Assert.DoesNotThrow(() => readFile.GetAllLines(path));
        }

        [Test]
        public void CheckGetAllLines_UnauthorizedAccessException()
        {
            //Arrange
            FileWrapper readFile = new FileWrapper();
            string path = "C://Temp//UnitTests//TestAccess.txt";

            //Act
            CreateFile(path, String.Empty);

            //Assert
            Assert.DoesNotThrow(() => readFile.GetAllLines(path));
        }

        private void CreateFile(string path, string content)
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(path);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }
        }
    }
}
