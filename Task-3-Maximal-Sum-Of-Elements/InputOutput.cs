using Serilog;

namespace Task_3_Maximal_Sum_Of_Elements
{
    public class InputOutput : IInputOutput
    {
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
                Log.Error("Could not get file path: {}", e.Message);
                throw;
            }
        }

        public void PrintNumbersOfLines(List<int> lines)
        {
            string result = String.Join(", ", lines);
            Console.WriteLine($"{result}");
        }

        private string GetPathFromConsole()
        {
            string filePath = @"" + Console.ReadLine();
            Log.Debug("Console file path: {filePath}", filePath);
            return filePath;
        }
    }
}
