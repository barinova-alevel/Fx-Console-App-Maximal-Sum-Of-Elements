
namespace Task_3_Maximal_Sum_Of_Elements
{
    internal class InputOutput : IInputOutput
    {
        public string GetPath(string filePathArg)
        {
            
            if (string.IsNullOrEmpty(filePathArg))
            {
                //add logger instead of console here
                //provide a possibility to get a path again
                Console.WriteLine($"{filePathArg} null or empty ");
            }

            //string filePath = Path.GetFileName(filePathArg);

            //if (File.Exists(filePathArg))
            //{
            //    Console.WriteLine($"The file {filePath} exists.");
            //}
            //else
            //{
            //    Console.WriteLine($"The file {filePath} in {filePathArg} does not exist.");
            //}
            string prefix = "--path=";
            int startIndex = filePathArg.IndexOf(prefix) + prefix.Length;
            string filePath = filePathArg.Substring(startIndex).Trim('"');

            return filePath;
        }

        public string GetPath()
        {
            Console.WriteLine("Enter Path");
            string filePath = @"" + Console.ReadLine();
            return filePath;
        }
    }
}
