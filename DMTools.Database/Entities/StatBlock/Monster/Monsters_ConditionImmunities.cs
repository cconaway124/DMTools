using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

[Table(name: "Monsters_x_ConditionImmunity", Schema = "monster")]
public partial class Monsters_ConditionImmunity
{
    [Key]
    public int Monsters_ConditionImmunitiesId { get; set; }
    [ForeignKey(name: "MonsterId")]
    public Monster Monster { get; set; }
    [ForeignKey(name: "ConditionImmunityId")]
    public ConditionImmunity ConditionImmunity { get; set; }
}
