using Newtonsoft.Json;
using DMToolsLibrary;
using DMToolsLibrary.StatBlocks;
using DMToolsLibrary.StatBlocks.StatBlockHelpers;

namespace DMToolsTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Speeds("30", "30", "30", "30", "30", true).ToString());

            string input = Console.ReadLine();

            using (FileStream file = File.Open(@input, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string json = sr.ReadToEnd();
                    FromJsonStatBlock sb = JsonConvert.DeserializeObject<FromJsonStatBlock>(json);
                    StatBlockFact sbFact = new StatBlockFact(json);
                    int temp = 0;
                }
            }
        }
    }
}