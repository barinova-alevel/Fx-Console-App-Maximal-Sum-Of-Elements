
using Serilog;

namespace MaxSum
{
    public class FileWrapper : IFileWrapper
    {
        public string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }

        public List<string> GetAllLines(string filePath)
        {
            List<string> allLines = new List<string>();
            try
            {
                if (!File.Exists(filePath))
                {
                    Log.Information($"File {filePath} does not exist.");
                    return allLines;
                }
                else if (File.ReadAllLines(filePath).Length == 0)
                {
                    throw new EmptyFileException("The file is empty.");
                }
                else
                {
                    Log.Information($"Reading file from {filePath}");
                    string[] linesArray = ReadAllLines(filePath);
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
                Log.Debug($"{ex.StackTrace}");
                return allLines;
            }

            catch (Exception ex)
            {
                Log.Error($"An error occurs while reading the file: {ex.Message}");
                return allLines;
            }
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
