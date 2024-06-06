using System.Text;

namespace MaxSum.UnitTests
{
    [TestFixture, Description("File tests")]

    internal class GetAllLinesTests
    {
        ReadFile readFile = new ReadFile();

        [TestCase("C://Temp//test.txt", "0,0,3\n1,-5,4", 2, new string[] { "0,0,3", "1,-5,4" })]//init test
        [TestCase("C://Temp//Test//test.txt", "My content\n1,-5,4", 2, new string[] { "My content", "1,-5,4" })]//path with nested folder
        [TestCase("C://Temp//test.txt", "2023-06-02 17:43:45\n2023-06-02 17:43:46", 2, new string[] { "2023-06-02 17:43:45", "2023-06-02 17:43:46" })] //date time content
        [TestCase("C://Temp//Test//test.json", "{\r\n\t\"name\": \"document-merge\"\n}", 3, new string[] { "{", "\t\"name\": \"document-merge\"", "}" })] // not txt format
        [TestCase("C://Temp//test.log", "2023-06-02 17:43:45 INFO  Field type =state\r\n2023-06-02 17:43:45 INFO  Field type =user\r\n2023-06-02 17:43:45 INFO  Field type =relationship\r\n2023-06-02 17:43:45 INFO  Field type =float", 4, new string[] { "2023-06-02 17:43:45 INFO  Field type =state", "2023-06-02 17:43:45 INFO  Field type =user", "2023-06-02 17:43:45 INFO  Field type =relationship", "2023-06-02 17:43:45 INFO  Field type =float" })] //more lines

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

        public void CheckGetAllLines_NullPassing()
        {
            //Arrange
            string path = null;

            //Act&Assert
            Assert.DoesNotThrow(() => readFile.GetAllLines(path));
        }

        public void CheckGetAllLines_EmptyFile()
        {
            //Arrange
            string path = "C://Temp//test.txt";

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
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
