using DMToolsLibrary.DiceCalculator;
using DMToolsLibrary.StatBlocks.StatBlockHelpers;
using static DMToolsLibrary.Enums.LibraryEnums;

namespace DMToolsLibrary.StatBlocks.Types;

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
        this.Speeds = new Speeds(
            jsonStatBlock.speed,
            jsonStatBlock.burrowSpeed,
            jsonStatBlock.climbSpeed,
            jsonStatBlock.flySpeed,
            jsonStatBlock.swimSpeed,
            jsonStatBlock.hover);
        this.CustomHp = jsonStatBlock.customHp;
        this.CustomSpeed = jsonStatBlock.customSpeed;
        this.Stats = new Stats(
            jsonStatBlock.strPoints,
            jsonStatBlock.dexPoints,
            jsonStatBlock.conPoints,
            jsonStatBlock.intPoints,
            jsonStatBlock.wisPoints,
            jsonStatBlock.chaPoints);
        this.HitDie = new HitDie(jsonStatBlock.hitDice, this.Size, 0/*this.Stats.GetCon()*/);
        this.Senses = new Senses(
            jsonStatBlock.blindsight,
            jsonStatBlock.blind,
            jsonStatBlock.darkvision,
            jsonStatBlock.tremorsense,
            jsonStatBlock.truesight,
            jsonStatBlock.telepathy, 
            (10 + this.Stats.Wis).ToString());
        this.Cr = jsonStatBlock.cr;
        this.CustomCr = jsonStatBlock.customCr;
        this.ProfBonus = this.CrToProfBonus(jsonStatBlock.cr, jsonStatBlock.customProf);
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
        this.Abilities = this.CreateActions(jsonStatBlock.abilities, "Abilities");
        this.Actions = this.CreateActions(jsonStatBlock.actions, "Actions");
        this.BonusActions = this.CreateActions(jsonStatBlock.bonusActions, "Bonus Actions");
        this.Reactions = this.CreateActions(jsonStatBlock.reactions, "Reactions");
        this.Legendaries = this.CreateActions(jsonStatBlock.legendaries, "Legendary Actions", AddActionDescription(jsonStatBlock.isLegendary, jsonStatBlock.legendariesDescription));
        this.Mythics = this.CreateActions(jsonStatBlock.mythics, "Mythic Actions", AddActionDescription(jsonStatBlock.isMythic, jsonStatBlock.mythicDescription));
        this.Lairs = this.CreateActions(jsonStatBlock.lairs, "Lair Actions", AddActionDescription(jsonStatBlock.isLair, jsonStatBlock.lairDescription));
        this.Regionals = this.CreateActions(jsonStatBlock.regionals, "Reional Effects", AddActionDescription(jsonStatBlock.isRegional, jsonStatBlock.regionalDescription + "\n\n" + jsonStatBlock.regionalDescriptionEnd));
        this.Sthrows = new SavingThrows(jsonStatBlock.sthrows, this.Stats, this.ProfBonus);
        this.Mskills = new Skills(jsonStatBlock.skills, this.Stats, this.ProfBonus);
        this.ConditionImmunities = jsonStatBlock.conditions;
        this.Languages = this.CreateLanguages(jsonStatBlock.languages); 
        this.UnderstandsBut = jsonStatBlock.understandsBut;
        this.ShortName = jsonStatBlock.shortName;
        this.PluralName = jsonStatBlock.pluralName;
        this.DoubleColumns = jsonStatBlock.doubleColumns;
        this.SeparationPoint = jsonStatBlock.separationPoint;
        this.Damage = jsonStatBlock.damage;
        this.DamageTypes = jsonStatBlock.damageTypes;
    }

    private string AddActionDescription(bool isType, string desc)
    {
        return (isType) ? desc : string.Empty;
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

    private MonsterActions CreateActions(Dictionary<string, string>[] actions, string actionName, string actionDescription = "")
    {
        return new MonsterActions(actions, actionName, actionDescription);
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

    private int CrToProfBonus(string cr, int customProf)
    {
        if (!double.TryParse(cr, out double dCr))
        {
            this.IsCustomCr = true;
            return customProf;
        }

        // fuck me this is ugly. Probably a better way to implement
        // TODO: git gud
        if (dCr >= 0 && dCr <= 4)
            return 2;
        else if (dCr >= 5 && dCr <= 8)
            return 3;
        else if (dCr >= 9 && dCr <= 12)
            return 4;
        else if (dCr >= 13 && dCr <= 16)
            return 5;
        else if (dCr >= 17 && dCr <= 20)
            return 6;
        else if (dCr >= 21 && dCr <= 24)
            return 7;
        else if (dCr >= 25 && dCr <= 28)
            return 3;
        else if (dCr >= 29)
            return 9;
        else
            return 0;
    }

    internal static string BlockType { get => "Monster"; }

    public string Tag { get; set; }

    public string Cr { get; set; }

    public bool IsCustomCr { get; set; }

    public string CustomCr { get; set; }

    public int ProfBonus { get; set; }

    public string Type { get; set; }

    public MonsterActions Abilities { get; set; }

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
