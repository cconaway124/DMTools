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
	public int AcId { get; set; }
	public string ArmorName { get; set; }
	public int AllowsDexMod { get; set; }
    [ForeignKey(name: "MonsterId")]
    public virtual Monster Monster { get; set; }
}
