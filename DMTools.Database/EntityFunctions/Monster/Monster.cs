using static DMTools.Shared.Enums.LibraryEnums;
using DMTools.Shared.DiceCalculator;
using DMTools.Shared;
using DMTools.Shared.Enums;

namespace DMTools.Database.Entities;

public partial class Monster : StatBlock
{
    private object[] Damage;
    private Properties Properties { get; set; }
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
        this.ShortName = jsonStatBlock.shortName;
        this.PluralName = jsonStatBlock.pluralName;
        this.RegionalDescriptionEnd = jsonStatBlock.regionalDescriptionEnd;
        this.Abilities = this.CreateActions(jsonStatBlock.abilities, "Abilities", this.Stats, this.ProfBonus, this.ShortName, this.PluralName);
        this.Actions = this.CreateActions(jsonStatBlock.actions, "Actions", this.Stats, this.ProfBonus, this.ShortName, this.PluralName);
        this.BonusActions = this.CreateActions(jsonStatBlock.bonusActions, "Bonus Actions", this.Stats, this.ProfBonus, this.ShortName, this.PluralName);
        this.Reactions = this.CreateActions(jsonStatBlock.reactions, "Reactions", this.Stats, this.ProfBonus, this.ShortName, this.PluralName);
        this.Legendaries = this.CreateActions(jsonStatBlock.legendaries, "Legendary Actions", this.Stats, this.ProfBonus, this.ShortName, this.PluralName, AddActionDescription(jsonStatBlock.isLegendary, jsonStatBlock.legendariesDescription));
        this.Mythics = this.CreateActions(jsonStatBlock.mythics, "Mythic Actions", this.Stats, this.ProfBonus, this.ShortName, this.PluralName, AddActionDescription(jsonStatBlock.isMythic, jsonStatBlock.mythicDescription));
        this.Lairs = this.CreateActions(jsonStatBlock.lairs, "Lair Actions", this.Stats, this.ProfBonus, this.ShortName, this.PluralName, AddActionDescription(jsonStatBlock.isLair, jsonStatBlock.lairDescription));
        this.Regionals = this.CreateActions(jsonStatBlock.regionals, "Regional Effects", this.Stats, this.ProfBonus, this.ShortName, this.PluralName, AddActionDescription(jsonStatBlock.isRegional, jsonStatBlock.regionalDescription + "\n\n" + jsonStatBlock.regionalDescriptionEnd));
        this.Sthrows = new SavingThrows(jsonStatBlock.sthrows, this.Stats, this.ProfBonus);
        this.Mskills = new Skills(jsonStatBlock.skills, this.Stats, this.ProfBonus).ConvertToList();
        this.ConditionImmunity = Entities.ConditionImmunity.CreateConditionImmunities(jsonStatBlock.conditions);
        this.Languages = new Languages(jsonStatBlock.languages, jsonStatBlock.understandsBut).ConvertToList();
        this.DoubleColumns = jsonStatBlock.doubleColumns;
        this.SeparationPoint = jsonStatBlock.separationPoint;
        this.Damage = jsonStatBlock.damage;
        this.DamageTypes = new DamageTypes(jsonStatBlock.damageTypes).ToList();
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

    private List<MonsterActions> CreateActions(Dictionary<string, string>[] actions,
        string actionType,
        Stats stats,
        int profBonus,
        string shortenedName,
        string pluralName,
        string actionDescription = ""
        )
    {
        return new MonsterActions(actions, LibraryEnums.ActionStrToEnum(actionType), actionDescription, stats, profBonus, shortenedName, pluralName).ConvertToList();
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
}
