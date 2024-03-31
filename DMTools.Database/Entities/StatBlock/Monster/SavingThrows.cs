using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

[Table(name: "SavingThrows", Schema = "monster")]
public partial class SavingThrows
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SavingThrowId { get; set; }
    public int ProfBonus { get; set; }
    public int? Str { get; set; }
    public int? Dex { get; set; }
    public int? Con { get; set; }
    public int? Int { get; set; }
    public int? Wis { get; set; }
    public int? Cha { get; set; }
    [ForeignKey(name: "Monster")]
    public int MonsterId { get; set; }
    public virtual Monster Monster { get; set; }
}
