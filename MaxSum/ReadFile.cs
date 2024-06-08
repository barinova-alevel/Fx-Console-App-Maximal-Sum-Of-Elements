using Serilog;

namespace MaxSum
{
    public class ReadFile : IReadFile
    {
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
                else
                {
                    Log.Information($"Reading file from {filePath}");
                    string[] linesArray = File.ReadAllLines(filePath);
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

            catch (Exception ex)
            {
                Log.Error($"An error occured while reading the file: {ex.Message}");
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

