using DMToolsLibrary.DiceCalculator;
using DMToolsLibrary.StatBlocks.StatBlockHelpers;
using static DMToolsLibrary.Enums.LibraryEnums;

namespace DMToolsLibrary.StatBlocks.Types
{
    public class Monster : StatBlock
    {
        public Monster() { }

        public Monster(FromJsonStatBlock jsonStatBlock)
        {
            this.Name = jsonStatBlock.name;
            this.Size = this.SizeStrToEnum(jsonStatBlock.size);
            this.Type = jsonStatBlock.type;
            this.Tag = jsonStatBlock.tag;
            this.Alignment = jsonStatBlock.alignment;
            this.ArmorName = jsonStatBlock.armorName;
            this.ShieldBonus = jsonStatBlock.shieldBonus;
            this.NatArmorBonus = jsonStatBlock.natArmorBonus;
            this.OtherArmorDesc = jsonStatBlock.otherArmorDesc;
            this.Speeds = this.StrSpeedsToSpeeds(
                jsonStatBlock.speed,
                jsonStatBlock.burrowSpeed,
                jsonStatBlock.climbSpeed,
                jsonStatBlock.flySpeed,
                jsonStatBlock.swimSpeed,
                jsonStatBlock.hover);
            this.CustomHp = jsonStatBlock.customHp;
            this.CustomSpeed = jsonStatBlock.customSpeed;
            this.Stats = this.StrStatsToStats(
                jsonStatBlock.strPoints,
                jsonStatBlock.dexPoints,
                jsonStatBlock.conPoints,
                jsonStatBlock.intPoints,
                jsonStatBlock.wisPoints,
                jsonStatBlock.chaPoints);
            this.HitDie = new HitDie(jsonStatBlock.hitDice, this.Size, this.Stats.GetCon());
            this.Senses = this.StrSensesToSenses(
                jsonStatBlock.blindsight,
                jsonStatBlock.blind,
                jsonStatBlock.darkvision,
                jsonStatBlock.tremorsense,
                jsonStatBlock.truesight,
                jsonStatBlock.telepathy);
            this.Cr = jsonStatBlock.cr;
            this.CustomCr = jsonStatBlock.customCr;
            this.CustomProf = jsonStatBlock.customProf;
            this.IsLegendary = jsonStatBlock.isLegendary; 
            this.LegendariesDescription = jsonStatBlock.legendariesDescription;
            this.IsLair = jsonStatBlock.isLair;
            this.LairDescription = jsonStatBlock.lairDescription;
            this.LairDescriptionEnd = jsonStatBlock.lairDescriptionEnd;
            this.IsMythic = jsonStatBlock.isMythic;
            this.MythicDescription = jsonStatBlock.mythicDescription;
            this.IsRegional = jsonStatBlock.isRegional;
            this.RegionalDescription = jsonStatBlock.regionalDescription;
            this.RegionalDescriptionEnd = jsonStatBlock.regionalDescriptionEnd;
            this.Abilities = jsonStatBlock.abilities;
            this.Actions = this.CreateActions(jsonStatBlock.actions);
            this.BonusActions = this.CreateActions(jsonStatBlock.bonusActions);
            this.Reactions = this.CreateActions(jsonStatBlock.reactions);
            this.Legendaries = this.CreateActions(jsonStatBlock.legendaries);
            this.Mythics = this.CreateActions(jsonStatBlock.mythics);
            this.Lairs = this.CreateActions(jsonStatBlock.lairs);
            this.Regionals = this.CreateActions(jsonStatBlock.regionals);
            this.Sthrows = this.CreateSavingThrows(jsonStatBlock.sthrows);
            this.Mskills = this.CreateSkills(jsonStatBlock.skills);
            this.ConditionImmunities = jsonStatBlock.conditions;
            this.Languages = this.CreateLanguages(jsonStatBlock.languages);
            this.UnderstandsBut = jsonStatBlock.understandsBut;
            this.ShortName = jsonStatBlock.shortName;
            this.PluralName = jsonStatBlock.pluralName;
            this.DoubleColumns = jsonStatBlock.doubleColumns;
            this.SeparationPoint = jsonStatBlock.separationPoint;
            this.Damage = jsonStatBlock.damage;
        }

        private SizeEnum SizeStrToEnum(string size)
        {
            size = size.ToLower();
            switch (size)
            {
                case "tiny":
                    return SizeEnum.Tiny;

                case "Small":
                    return SizeEnum.Small;

                case "Medium":
                    return SizeEnum.Medium;

                case "large":
                    return SizeEnum.Large;

                case "huge":
                    return SizeEnum.Huge;

                case "gargantuan":
                    return SizeEnum.Gargantuan;
                default:
                    return SizeEnum.None;
            }
        }

        private Speeds StrSpeedsToSpeeds(
            string speed, 
            string burrowSpeed,
            string climbSpeed,
            string flySpeed,
            string swimSpeed,
            bool hover)
        {
            return null;
        }

        private Stats StrStatsToStats(
            string str,
            string dex,
            string con,
            string inte,
            string wis,
            string cha)
        {
            return null;
        }

        private Senses StrSensesToSenses(
            string blindsight,
            bool blind,
            string darkvision,
            string tremorsense,
            string truesight,
            string telepathy)
        {
            return null;
        }

        private MonsterActions StrActionToActions(string str) {
            return null;
        }

        private MonsterActions CreateActions(Dictionary<string, string>[] actions)
        {
            return null;
        }

        private Skills CreateSkills(Dictionary<string, string>[] skills)
        {
            return null;
        }

        private DamageTypes CreateDamageTypes(Dictionary<string, string>[] dTypes)
        {
            return null;
        }

        private DamageTypes CreateSpecialDTypes(Dictionary<string, string>[] dTypes)
        {
            return null;
        }

        private Languages CreateLanguages(Dictionary<string, string>[] languages)
        {
            return null;
        }

        private SavingThrows CreateSavingThrows(Dictionary<string, string>[] sThrows)
        {
            return null;
        }

        internal static string BlockType { get => "Monster"; }

        public string Tag { get; set; }

        public string Cr { get; set; }

        public string CustomCr { get; set; }

        public int CustomProf { get; set; }

        public string Type { get; set; }

        public Dictionary<string, string>[] Abilities { get; set; }

        public MonsterActions Actions { get; set; }

        public MonsterActions BonusActions { get; set; }

        public MonsterActions Reactions { get; set; }

        public MonsterActions Legendaries { get; set; }

        public MonsterActions Mythics { get; set; }

        public MonsterActions Lairs { get; set; }

        public MonsterActions Regionals { get; set; }

        public SavingThrows Sthrows { get; set; }

        public Skills Mskills { get; set; }

        public Dictionary<string, string>[] DamageTypes { get; set; }

        public Dictionary<string, string>[] ConditionImmunities { get; set; }

        public string ArmorName { get; set; }

        public int ShieldBonus { get; set; }

        public string NatArmorBonus { get; set; }

        public string OtherArmorDesc { get; set; }

        public bool CustomHp { get; set; }

        public bool CustomSpeed { get; set; }

        public bool IsLegendary { get; set; }

        public string LegendariesDescription { get; set; }

        public bool IsLair { get; set; }

        public string LairDescription { get; set; }

        public string LairDescriptionEnd { get; set; }

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
