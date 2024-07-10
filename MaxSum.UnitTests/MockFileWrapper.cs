

using Serilog;

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
            List<string> allLines = new List<string>();
            try
            {
                if (!File.Exists(path))
                {
                    Log.Information($"File {path} does not exist.");
                    return allLines;
                }
                else if (File.ReadAllLines(path).Length == 0)
                {
                    throw new EmptyFileException("The file is empty.");
                }
                else
                {
                    Log.Information($"Reading file from {path}");
                    string[] linesArray = ReadAllLines(path);
                    allLines.AddRange(linesArray);
                    return allLines;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Error($"Error: Access to the file is denied. {ex.Message}");
                HandleUnauthorizedAccessException();
                return allLines;
            }

            catch (EmptyFileException ex)
            {
                Log.Information($"Failed to read any line from the file. {ex.Message}");
                return allLines;
            }

            catch (Exception ex)
            {
                Log.Error($"An error occurs while reading the file: {ex.Message}");
                return allLines;
            }
        }

        public string[] ReadAllLines(string path)
        {
            if (_throwUnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException("Access to the path is denied.");
            }
            return File.ReadAllLines(path);
        }

        private void HandleUnauthorizedAccessException()
        {
            Console.WriteLine("Do you want to continue running the program? (yes/no)");
            string userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "no")
            {
                Console.WriteLine("Exiting program.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please, enter file path manually:");
                string filePath = @"" + Console.ReadLine();
                Log.Debug("Console file path: {filePath}", filePath);
                GetAllLines(filePath);
            }
        }
    }
}
