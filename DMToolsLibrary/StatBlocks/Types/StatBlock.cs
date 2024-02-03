using DMToolsLibrary.DiceCalculator;
using DMToolsLibrary.StatBlocks.StatBlockHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMToolsLibrary.Enums.LibraryEnums;

namespace DMToolsLibrary.StatBlocks.Types
{
    public abstract class StatBlock
    {
		public string Name { get; set; }

		public SizeEnum Size { get; set;}

        public AC ArmorClass { get; set;}

        public int HitPoints { get; set;}

        public HitDie HitDie { get; set;}

        public int Speed { get; set;}

        public Stats Stats { get; set;}

        public Senses Senses { get; set;}

        public string Alignment { get; set;}

        public Speeds Speeds { get; set;}

        public Languages Languages { get; set;}
    }
}
