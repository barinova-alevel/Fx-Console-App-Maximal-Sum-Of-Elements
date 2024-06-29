

namespace MaxSum.UnitTests
{
    public class MockFileWrapper : IFileWrapper
    {
        private readonly bool _throwUnauthorizedAccessException;
        
        public MockFileWrapper(bool throwUnauthorizedAccessException = false)
        {
            _throwUnauthorizedAccessException = throwUnauthorizedAccessException;
        }

        public List<string> GetAllLines(string path)
        {
            throw new NotImplementedException();
        }

        public string[] ReadAllLines(string path)
        {
            if (_throwUnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Access to the path is denied.");
            }
            return File.ReadAllLines(path);
        }
    }
}
