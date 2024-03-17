using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

[Table(name: "Actions", Schema = "monster")]
public class Actions
{
    [Key]
    public int ActionId { get; set; }
    public string Action { get; set; }
    public string ActionRules { get; set; }
    [ForeignKey(name: "MonsterActionId")]
    public MonsterActions MonsterActions { get; set; }
}
