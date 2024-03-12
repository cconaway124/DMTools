using System.ComponentModel.DataAnnotations;

namespace DMTools.Database.Entities;

public partial class MonsterActions
{
    [Key]
    public int MonsterActionId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
