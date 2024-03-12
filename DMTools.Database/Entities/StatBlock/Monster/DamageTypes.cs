using DMTools.Database.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public partial class DamageTypes
{
	[Key]
	public int DamageTypeId { get; set; }
	public int Type { get; set; }
	[ForeignKey(name: "MonsterId")]
	public virtual Monster Monster { get; set; }
}
