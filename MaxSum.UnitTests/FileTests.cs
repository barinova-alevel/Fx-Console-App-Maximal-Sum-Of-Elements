using System.Text;

namespace MaxSum.UnitTests
{
    [TestFixture, Description("File tests")]
    internal class FileTests
    {
        //move this method in TestsHelper class?
        protected void CreateFile(string path, string content)
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

        [TestCase("C:\\Temp\\Test\\test.txt", "My content \n1,-5,4")]
        public void CheckReadFile_txt(string filePath, string content)
        {
            //Arrange
            ReadFile targetFile = new ReadFile();

            //Act
            CreateFile(filePath, content);
            targetFile.ReadLines(filePath);

            //Assert
            //Assert.IsTrue(File.Exists(filePath)

        }
    }
}
