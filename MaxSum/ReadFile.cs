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
                    Log.Debug($"File {filePath} does not exist.");
                    return null;
                }
                else
                {
                    Log.Information($"Reading file from {filePath}");
                    string[] linesArray = File.ReadAllLines(filePath);
                    allLines.AddRange(linesArray);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"An error occured while reading the file: {ex.Message}");
            }
            return allLines;
        }
    }
}
