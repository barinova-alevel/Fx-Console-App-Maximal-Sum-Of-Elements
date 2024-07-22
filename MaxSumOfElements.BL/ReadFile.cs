using Serilog;

namespace MaxSumOfElements.BL
{
    public class ReadFile
    {
        public List<string> ReadLines(string path)
        {
            List<string> lines = new List<string>();
            int bufferSize = 1024;

            try
            {
                if (path != null)
                {
                    using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8, true, bufferSize))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            Log.Information($"Reading {line}");
                            lines.Add(line);
                        }
                    }
                }
                else
                {
                    Log.Information("Path is missing.");
                }
                return lines;
            }
            catch (Exception ex)
            {
                Log.Information(ex.Message);
                return lines;
            }
        }
    }
}
