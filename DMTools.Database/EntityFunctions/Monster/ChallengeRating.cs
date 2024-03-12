using DMTools.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public partial class ChallengeRating
{
	public ChallengeRating() { }
	public ChallengeRating(string cr, string customCr)
	{
		this.Cr = cr;
		Constants.crToXp.TryGetValue(cr, out string? xP);

		this.Xp = xP ?? "";

		this.CustomCr = customCr;
	}

	public override string ToString()
	{
		if (this.Cr == null)
			return CustomCr;

		return $"{this.Cr} ({this.Xp} XP)";
	}
}	
