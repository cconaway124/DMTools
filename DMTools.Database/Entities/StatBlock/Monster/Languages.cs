using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public partial class Languages
{
	[Key]
	public int LanguageId { get; set; }
	public string LanguageName { get; set; }
	public int LanguageLevel { get; set; }
	[ForeignKey(name: "MonsterId")]
	public virtual Monster Monster { get; set; }
}
