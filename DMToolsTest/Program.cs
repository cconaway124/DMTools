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
            Console.WriteLine(StatBlockStringReplacer.ReplaceBracketModifiers(@"Ranged Spell Attack: [CHA ATK + 3] to hit, range 120 ft., one target. Hit: [CHA 1D10] force damage.
A beam of crackling energy streaks toward a creature within range. Make a ranged spell attack against the target. On a hit, the target takes [1d8] fire damage.
[MON] can create 2 bolts of fire.", new Stats(16, 18, 15, 8, 8, 10), 2, "Fallen", "The Fallen"));

            Console.WriteLine(new Speeds("30", "30", "30", "30", "30", true).ToString());
            Stats stats = new Stats(20, 18, 25, 5, 10, 1);
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(stats.ToString((StatType)i));
            }

            Console.WriteLine(new Senses("5", true, "0", "0", "0", "0", "13").ToString());

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