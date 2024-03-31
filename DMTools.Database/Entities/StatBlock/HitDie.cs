using DMTools.Database.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

[Table(name: "HitDie", Schema = "monster")]
public partial class HitDie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int HitDieId { get; set; }
    public int Count { get; set; }
    public string HitDieType { get; set; }
    public string ConMod { get; set; }
    public int AverageHp { get; set; }
    [ForeignKey(name: "MonsterId")]
    public Monster Monster { get; set; }
}

