using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMTools.Database.Entities;

[Table(name: "MonsterActions", Schema = "monster")]
public partial class MonsterActions
{
    [Key]
    public int MonsterActionId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ActionType { get; set; }
    [ForeignKey(name: "MonsterId")]
    public virtual Monster Monster { get; set; }
}
