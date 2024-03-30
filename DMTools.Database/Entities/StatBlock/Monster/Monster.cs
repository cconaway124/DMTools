using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMTools.Database.Entities;

[Table(name: "Monster", Schema = "monster")]
public partial class Monster : StatBlock
{
    [Key]
    public int MonsterId { get; set; }

    public string Tag { get; set; }

    public virtual ChallengeRating Cr { get; set; }

    public bool IsCustomCr { get; set; }

    public string CustomCr { get; set; }

    public int ProfBonus { get; set; }

    public string Type { get; set; }
    [InverseProperty(nameof(MonsterActions))]
    public virtual ICollection<MonsterActions> Abilities { get; set; }
    [NotMapped]
    public virtual ICollection<MonsterActions> Actions { get; set; }
    [NotMapped]
    public virtual ICollection<MonsterActions> BonusActions { get; set; }
    [NotMapped]
    public virtual ICollection<MonsterActions> Reactions { get; set; }
    [NotMapped]
    public virtual ICollection<MonsterActions> Legendaries { get; set; }
    [NotMapped]
    public virtual ICollection<MonsterActions> Mythics { get; set; }
    [NotMapped]
    public virtual ICollection<MonsterActions> Lairs { get; set; }
    [NotMapped]
    public virtual ICollection<MonsterActions> Regionals { get; set; }
    [NotMapped]
    public virtual SavingThrows Sthrows { get; set; }
    [NotMapped]
    public virtual ICollection<Skills> Mskills { get; set; }
    [NotMapped]
    public virtual ICollection<DamageTypes> DamageTypes { get; set; }
    [NotMapped]
    public virtual ICollection<ConditionImmunity> ConditionImmunity { get; set; }
    [NotMapped]
    public virtual ICollection<Languages> Languages { get; set; }

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

    public string ShortName { get; set; }

    public string PluralName { get; set; }

    public bool DoubleColumns { get; set; }

    public int SeparationPoint { get; set; }
    public string UserGuid { get; set; }
}
