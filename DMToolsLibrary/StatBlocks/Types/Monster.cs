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
		this.ArmorClass = new AC(jsonStatBlock.otherArmorDesc, jsonStatBlock.shieldBonus, jsonStatBlock.armorName, this.Stats.Dex, jsonStatBlock.natArmorBonus);
		this.HitDie = new HitDie(jsonStatBlock.hitDice, this.Size, this.Stats.Con);
        this.Senses = new Senses(
            jsonStatBlock.blindsight,
            jsonStatBlock.blind,
            jsonStatBlock.darkvision,
            jsonStatBlock.tremorsense,
            jsonStatBlock.truesight,
            jsonStatBlock.telepathy, 
            (10 + this.Stats.Wis).ToString());
        this.Cr = new ChallengeRating(jsonStatBlock.cr, jsonStatBlock.customCr);
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
        this.ConditionImmunities = new ConditionImmunities(jsonStatBlock.conditions);
        this.Languages = new Languages(jsonStatBlock.languages, jsonStatBlock.understandsBut);
        this.ShortName = jsonStatBlock.shortName;
        this.PluralName = jsonStatBlock.pluralName;
        this.DoubleColumns = jsonStatBlock.doubleColumns;
        this.SeparationPoint = jsonStatBlock.separationPoint;
        this.Damage = jsonStatBlock.damage;
        this.DamageTypes = new DamageTypes(jsonStatBlock.damageTypes);
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

            case "small":
                return SizeEnum.Small;

            case "medium":
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

    private MonsterActions CreateActions(Dictionary<string, string>[] actions, string actionName, string actionDescription = "")
    {
        return new MonsterActions(actions, actionName, actionDescription);
    }

    private int CrToProfBonus(string cr, int customProf)
    {
        if (!double.TryParse(cr, out double dCr))
        {
            this.IsCustomCr = true;
            return customProf;
        }

        if (dCr < 0)
            return 0;

        // fuck me this is ugly. Probably a better way to implement
        // TODO: git gud
        // DONE: Got gud

        int intCr = ((int)dCr - 1) / 4;
        return intCr + 2;
    }

    internal static string BlockType { get => "Monster"; }

    public string Tag { get; set; }

    public ChallengeRating Cr { get; set; }

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

    public DamageTypes DamageTypes { get; set; }

    public ConditionImmunities ConditionImmunities { get; set; }

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

    public string ShortName { get; set; }

    public string PluralName { get; set; }

    public bool DoubleColumns { get; set; }

    public int SeparationPoint { get; set; }

    public object[] Damage { get; set; }
}
