namespace MaxSumOfElements.Exceptions
{
    public class ReadFile
    {
        //Що ти отримала пас взагалі
        //Що пас в форматі саме шляху до файлу
//Що файл за цим пасом існує
//Що файл за цим пасом не пустий
        List<string> ReadLines(string path)
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                { 
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                return lines;
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
