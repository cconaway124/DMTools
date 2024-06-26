﻿using Newtonsoft.Json;
using DMTools;
using DMTools.StatBlocks;

using static DMTools.Shared.Enums.LibraryEnums;
using DMTools.Database.Entities;
using DMTools.Shared;

namespace DMToolsTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(DMTools.Database.Entities.StatBlockStringReplacer.ReplaceBracketModifiers(@"[3D6 - 14]", new Stats(16, 18, 15, 8, 8, 10), 2, "Fallen", "The Fallen"));

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