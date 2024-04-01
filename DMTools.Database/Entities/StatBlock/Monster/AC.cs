using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

[Table(name: "ArmorClass", Schema = "monster")]
public partial class AC
{
	[Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AcId { get; set; }
	public string ArmorName { get; set; }
	public int AllowsDexMod { get; set; }
	public int ShieldBonus { get; set; }
	public int? NaturalArmorBonus { get; set; }
	public int? DexBonus { get; set; }
    [ForeignKey(name: "Monster")]
    public int MonsterId { get; set; }
	public virtual Monster Monster { get; set; }
}
