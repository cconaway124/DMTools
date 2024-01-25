using DMToolsLibrary.DiceCalculator;
using DMToolsLibrary.StatBlocks.StatBlockHelpers;
using static DMToolsLibrary.Enums.LibraryEnums;

namespace DMToolsLibrary.StatBlocks.Types
{
    public class Monster : StatBlock
    {
        internal static string BlockType { get => "Monster"; }

        public string Tag { get; set; }

        public string Cr { get; set; }

        public string CustomCr { get; set; }

        public string CustomProf { get; set; }

        public string Type { get; set; }

        public Dictionary<string, string> Abilities { get; set; }

        public MonsterActions Actions { get; set; }

        public MonsterActions BonusActions { get; set; }

        public MonsterActions Reactions { get; set; }

        public MonsterActions Legendaries { get; set; }

        public MonsterActions Mythics { get; set; }

        public MonsterActions Lairs { get; set; }

        public MonsterActions Regionals { get; set; }

        public Dictionary<string, string> Sthrows { get; set; }

        public Dictionary<string, string> Skills { get; set; }

        public Dictionary<string, string> DamageTypes { get; set; }

        public Dictionary<string, string> ConditionImmunities { get; set; }

        public string ArmorName { get; set; }

        public int ShieldBonus { get; set; }

        public string NatArmorBonus { get; set; }

        public string OtherArmorDesc { get; set; }

        public int CustomHp { get; set; }

        public bool IsLegendary { get; set; }

        public string LegendariesDescription { get; set; }

        public bool IsLair { get; set; }

        public string LairDescription { get; set; }

        public bool IsMythic { get; set; }

        public string MythicDescription { get; set; }

        public bool IsRegional { get; set; }

        public string RegionalDescription { get; set; }

        public string RegionalDescriptionEnd { get; set; }

        public Properties Properties { get; set; }

        public string UnderstandsBut { get; set; }

        public string ShortName { get; set; }

        public string PluralName { get; set; }

        public bool DoubleColumns { get; set; }

        public int SeparationPoint { get; set; }

        public object[] Damage { get; set; }
    }
}
