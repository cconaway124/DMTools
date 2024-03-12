using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.StatBlocks.StatBlockHelpers;

public partial class AC
{
	[Key]
	public int AcId { get; set; }
	public string ArmorName { get; set; }
	public int AllowsDexMod { get; set; }
}
