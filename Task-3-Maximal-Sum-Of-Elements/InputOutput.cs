
using Serilog;

namespace Task_3_Maximal_Sum_Of_Elements
{
    internal class InputOutput : IInputOutput
    {
        public string GetPath(string filePathArg)
        {
            try
            {
                Log.Debug("Getting file path from {filePathArg} ", filePathArg);

                if (string.IsNullOrEmpty(filePathArg))
                {
                    Log.Debug("filePathArg is null or empty");
                    //provide a possibility to get a path again
                }
                else
                {
                    string prefix = "--path=";
                    int startIndex = filePathArg.IndexOf(prefix) + prefix.Length;
                    string filePath = filePathArg.Substring(startIndex).Trim('"');
                    Log.Debug("File path: {filePath}", filePath);
                    return filePath;
               }
                //not correct
                return "";
            }
            catch (Exception e) {
                Log.Error("Could not get file path: {}", e.Message, e);
                //not correct
                return "1";
            }
            
        }

            public string GetPath()
            {
                Console.WriteLine("Enter Path");
                string filePath = @"" + Console.ReadLine();
                return filePath;
            }
        }
    }
