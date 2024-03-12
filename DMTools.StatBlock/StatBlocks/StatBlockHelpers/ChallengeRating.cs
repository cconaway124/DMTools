using DMTools.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.StatBlocks.StatBlockHelpers;

public partial class ChallengeRating
{
	private string cr;
	private string xP;
	private string customCr;

	public ChallengeRating(string cr, string customCr)
	{
		this.cr = cr;
		Constants.crToXp.TryGetValue(cr, out string? xP);

		this.xP = xP ?? "";

		this.customCr = customCr;
	}

	public override string ToString()
	{
		if (this.cr == null)
			return customCr;

		return $"{this.cr} ({this.xP} XP)";
	}
}	
