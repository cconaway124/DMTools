using DMTools.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public partial class ChallengeRating
{
	[Key]
	public int ChallengeRatingId { get; set; }
	[ForeignKey(name: "MonsterId")]
	public virtual Monster Monster { get; set; }
	public string Cr { get; set; }
	public string Xp { get; set; }
	public string CustomCr { get; set; }
}
