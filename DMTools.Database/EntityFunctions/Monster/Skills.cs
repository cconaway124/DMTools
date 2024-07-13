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
	private Dictionary<string, int> skills = new();

	public Skills() { }

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

			this.skills[name] = mod + profBonus;
		}
	}

	public List<Skills> ConvertToList()
	{
		List<Skills> skills = new List<Skills>();

		foreach (KeyValuePair<string, int> pair in this.skills)
		{
			skills.Add(new Skills
			{
				Name = pair.Key,
				Bonus = pair.Value,
			});
		}

		return skills;
	}

	public int Count
	{
		get => this.skills.Count;
	}

	public override string ToString()
	{
		if (this.skills == null)
		{
			return $"{this.Name} {(this.Bonus > 0 ? "+" : "-")}{Math.Abs(this.Bonus)}";
		}

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
