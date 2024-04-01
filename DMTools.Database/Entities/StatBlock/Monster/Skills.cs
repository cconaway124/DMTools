using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

[Table(name: "Skills", Schema = "monster")]
public partial class Skills
{
	[Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SkillId { get; set; }
	public string Name { get; set; }
	public int Bonus { get; set; }
    [ForeignKey(name: "Monster")]
    public int MonsterId { get; set; }
    public virtual Monster Monster { get; set; }
}
