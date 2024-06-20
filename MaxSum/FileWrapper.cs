
namespace MaxSum
{
    public class FileWrapper : IFileWrapper
    {
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}
