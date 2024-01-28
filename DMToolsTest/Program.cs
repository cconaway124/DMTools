using Newtonsoft.Json;
using DMToolsLibrary;
using DMToolsLibrary.StatBlocks;
using DMToolsLibrary.StatBlocks.StatBlockHelpers;
using static DMToolsLibrary.Enums.LibraryEnums;

namespace DMToolsTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Speeds("30", "30", "30", "30", "30", true).ToString());
            Stats stats = new Stats(20, 18, 25, 5, 10, 1);
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(stats.ToString((StatType)i));
            }

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