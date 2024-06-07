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
            catch (Exception ex)
            {
                Log.Error($"An error occured while reading the file: {ex.Message}");
                throw;
            }
        }
    }
}
