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
        private string name;

        private SizeEnum size;

        private int armorClass;

        private int hitPoints;

        private HitDie hitDie;

        private int speed;

        private Stats stats;

        private Senses senses;

        private string alignment;

        private Speeds speeds;

        private Languages languages;
    }
}
