using MaxSumOfElements.BL;
using Serilog;

namespace MaxSumOfElements.UI
{
    public class InputOutput : IInputOutput
    {
        public void Run(string filePathArg)
        {
            while (true)
            {
                Console.WriteLine("Would you like to read a file? (yes/no): ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "no")
                {
                    Environment.Exit(1);
                }

                else if (userInput != "yes")
                {
                    Log.Information("Invalid input. Please enter 'yes' or 'no'.");
                }

                else if (userInput == "yes")
                {
                    string filePath = GetPath(filePathArg);
                    FileAnalyzer fileAnalyzer = new FileAnalyzer(filePath);
                    fileAnalyzer.Analyze();
                }
            }
        }
        public string GetPath(string filePathArg)
        {
            string filePath;
            try
            {
                Log.Debug("Getting file path from path argument {filePathArg} ", filePathArg);

                if (string.IsNullOrEmpty(filePathArg))
                {
                    Log.Information("file path argument is null or empty, please enter file path manually:");
                    string manualFilePath = GetPathFromConsole();
                    return manualFilePath;
                }

                else
                {
                    string prefix = "--path=";
                    int startIndex = filePathArg.IndexOf(prefix) + prefix.Length;
                    filePath = filePathArg.Substring(startIndex).Trim('"');
                    Log.Information("File path: {filePath}", filePath);
                    return filePath;
                }
            }
            catch (Exception e)
            {
                Log.Error("Could not get file path: {}", e.Message, e);
                throw;
            }
        }

        private string GetPathFromConsole()
        {
            string filePath = @"" + Console.ReadLine();
            Log.Debug("Console file path: {filePath}", filePath);
            if (IsValidPath(filePath))
            {
                return filePath;
            }
            else
            {
                Log.Information("Invalid path, would you like to try again? (yes/no)");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "no")
                {
                    Environment.Exit(1);
                }
                else 
                {
                    Log.Information("Enter path:");
                    GetPathFromConsole();
                }
                return filePath;
            }
        }

        private bool IsValidPath(string path)
        {
            bool isValid = false;

            try
            {
                isValid = Path.IsPathRooted(path) && !string.IsNullOrWhiteSpace(Path.GetFileName(path));
            }
            catch (Exception)
            {
                // Ignore exception and return false
            }

            return isValid;
        }
    }
}
