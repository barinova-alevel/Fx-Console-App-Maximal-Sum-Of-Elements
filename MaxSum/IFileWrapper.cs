
namespace MaxSum
{
    public interface IFileWrapper
    {
            public string[] ReadAllLines(string path);

        public List<string> GetAllLines(string path);
    }
}
