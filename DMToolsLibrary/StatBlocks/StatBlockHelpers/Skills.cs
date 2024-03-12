using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.StatBlocks.StatBlockHelpers;

public class Skills
{
	private Dictionary<string, int> skills;

	public Skills(Dictionary<string, string>[] skillDict, Stats stats, int profBonus)
	{
		this.skills = new Dictionary<string, int>();
		foreach (Dictionary<string, string> skill in skillDict)
		{
			skill.TryGetValue("name", out string? name);
			skill.TryGetValue("stat", out string? stat);

			if (stat == null || name == null)
			{
				continue; // probably should throw error here
			}

			StatType type = StrToStatType(stat);
			int mod = stats.GetAbilityMod(type);

			skills[name] = mod + profBonus;
		}
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		int count = 0;
		foreach (string key in this.skills.Keys)
		{
			if (count > 0)
				sb.Append(", ");

			int mod = this.skills[key];
			string sign = (mod > 0) ? "+" : "-";
			mod = Math.Abs(mod);

			sb.Append($"{key} {sign}{mod}");
			count++;
		}

		return sb.ToString();
	}
}
