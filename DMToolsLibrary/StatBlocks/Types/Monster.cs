using DMToolsLibrary.DiceCalculator;
using static DMToolsLibrary.Enums.LibraryEnums;

namespace DMToolsLibrary.StatBlocks.Types
{
    internal class Monster : StatBlock
    {
        internal static string BlockType { get => "Monster"; }

        private string tag;

        private string cr;

        private string customCr;

        private string customProf;

        private Dictionary<string, string> abilities;

        private Dictionary<string, string> actions;

        private Dictionary<string, string> bonusActions;

        private Dictionary<string, string> reactions;

        private Dictionary<string, string> legendaries;

        private Dictionary<string, string> mythics;

        private Dictionary<string, string> lairs;

        private Dictionary<string, string> regionals;

        private Dictionary<string, string> sthrows;

        private Dictionary<string, string> skills;

        private Dictionary<string, string> damageTypes;

        private string armorName;

        private int shieldBonus;

        private string natArmorBonus;

        private string otherArmorDesc;

        private int customHp;

        private bool isLegendary;

        private string legendariesDescription;

        private bool isLair;

        private string lairDescription;

        private bool isMythic;

        private string mythicDescription;

        private bool isRegional;

        private string regionalDescription;

        private string regionalDescriptionEnd;

        private string[] properties;

        private string understandsBut;

        private string shortName;

        private string pluralName;

        private bool doubleColumns;

        private int separationPoint;

        private object[] damage;
    }
}
