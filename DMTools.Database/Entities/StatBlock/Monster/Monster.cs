namespace DMTools.Database.Entities;

public partial class Monster : StatBlock
{
    public string MonsterId { get; set; }

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

    public ConditionImmunity ConditionImmunities { get; set; }

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
