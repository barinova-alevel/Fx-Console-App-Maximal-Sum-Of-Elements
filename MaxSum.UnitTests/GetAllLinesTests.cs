
using System;
using System.Text;

namespace MaxSum.UnitTests
{
    [TestFixture, Description("File tests")]

    internal class GetAllLinesTests
    {
        ReadFile readFile = new ReadFile();

        //[TestCase(null, "My content\n1,-5,4", new string[] { "My content", "1,-5,4" })] null checking
        //public void CheckGetAllLines(string? path, string content, string[] array)

        //[TestCase("", "My content\n1,-5,4", new string[] { "My content", "1,-5,4" })] //empty path

        [TestCase("C://Temp//test.txt", "My content\n1,-5,4", 2, new string[] {"My content", "1,-5,4" })]
        [TestCase("C://Temp//Test//test.txt", "My content\n1,-5,4", 2, new string[] {"My content", "1,-5,4" })] 
        //here continue playing with path and content
        
        public void CheckGetAllLines(string path, string content, int count, string[] array)
        {
            //Arrange
            List<string> result;
            List<string> expected = new List<string>(array);

            //Act
            CreateFile(path, content);
            result = readFile.GetAllLines(path);

            //Assert
            Assert.That(result.Count(), Is.EqualTo(count));
            Assert.That(result, Is.EqualTo(expected));
        }

        private void CreateFile(string path, string content)
        {
            //string path = @"C:\Temp\Test\test.txt";
            //string content = "My content \n1,-5,4";
            //string message3 = System.String.Empty;
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
                Console.WriteLine(ex.ToString());
            }
        }

    }
}
