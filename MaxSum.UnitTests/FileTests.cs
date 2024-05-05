using System.Text;

namespace MaxSum.UnitTests
{
    internal class FileTests
    {
        [SetUp]
        protected void SetUp()
        {
            string path = @"C:\Temp\Test\test.txt";
            string content = "My content \n1,-5,4";
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
