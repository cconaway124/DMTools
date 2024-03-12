using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public partial class Skills
{
	[Key]
	public int SkillId { get; set; }
	public string Name { get; set; }
	public int Bonus { get; set; }
    [ForeignKey(name: "MonsterId")]
    public Monster Monster { get; set; }
}
