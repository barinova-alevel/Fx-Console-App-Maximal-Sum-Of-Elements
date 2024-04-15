using Serilog;

namespace Task_3_Maximal_Sum_Of_Elements
{
    internal class InputOutput : IInputOutput
    {
        public string GetPath(string filePathArg)
        {
            string filePath;
            try
            {
                Log.Debug("Getting file path from {filePathArg} ", filePathArg);

                if (string.IsNullOrEmpty(filePathArg))
                {
                    Log.Debug("filePathArg is null or empty, enter the file path manually:");
                    string manualFilePath = GetPathFromConsole();
                    filePath= manualFilePath;
                }
                else
                {
                    string prefix = "--path=";
                    int startIndex = filePathArg.IndexOf(prefix) + prefix.Length;
                    filePath = filePathArg.Substring(startIndex).Trim('"');
                    Log.Debug("File path: {filePath}", filePath);
                    return filePath;
                }
                return filePath;
            }
            catch (Exception e)
            {
                Log.Error("Could not get file path: {}", e.Message, e);
                //not correct
                return "1";
            }

        }

        public string GetPathFromConsole()
        {
            string filePath = @"" + Console.ReadLine();
            Log.Debug("Console file path: {filePath}", filePath);
            //add check path format
            return filePath;
        }
    }
}
