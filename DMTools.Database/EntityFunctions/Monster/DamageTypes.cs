using System.ComponentModel;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public partial class DamageTypes
{
	Dictionary<DamageType, List<string>> damageTypes;

	public DamageTypes(Dictionary<string, string>[] dTypes)
	{
        this.damageTypes = new Dictionary<DamageType, List<string>>();
		this.damageTypes[DamageType.Immune] = new List<string>();
		this.damageTypes[DamageType.Resistant] = new List<string>();
		this.damageTypes[DamageType.Vulnerable] = new List<string>();

		foreach (Dictionary<string, string> dType in dTypes)
		{
			dType.TryGetValue("name", out string? name);
			dType.TryGetValue("type", out string? type);

			if (name == null || type == null)
				continue;

			if (type.ToLower() == "i")
			{
				damageTypes[DamageType.Immune].Add(name);
			}
			else if (type.ToLower() == "r")
			{
				damageTypes[DamageType.Resistant].Add(name);
			}
			else if (type.ToLower() == "v")
			{
				damageTypes[DamageType.Vulnerable].Add(name);
			}
			else
				continue;
		}
	}

	public Dictionary<DamageType, List<string>> Dtypes
	{
		get => this.damageTypes;
	}

	public string Immune
	{
		get => string.Join(", ", this.damageTypes[DamageType.Immune]);
	}

	public string Resistant
	{
		get => string.Join(", ", this.damageTypes[DamageType.Resistant]);
	}

	public string Vulnerable
	{
		get => string.Join(", ", this.damageTypes[DamageType.Vulnerable]);
	}
}
