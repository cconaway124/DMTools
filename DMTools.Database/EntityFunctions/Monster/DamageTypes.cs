using System.ComponentModel;
using System.Runtime.CompilerServices;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public partial class DamageTypes
{
	Dictionary<DamageType, List<string>> damageTypes;

	public DamageTypes() { }

	public DamageTypes(DamageType damageType, string description)
	{
		this.Type = (int)damageType;
		this.Description = description;
	}

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

	public List<DamageTypes> ToList()
	{
		List<DamageTypes> list = new List<DamageTypes>();
		foreach (KeyValuePair<DamageType, List<string>> pair in damageTypes)
		{
			list.Add(new DamageTypes(pair.Key, string.Join(", ", pair.Value)));
		}

		return list;
	}

	public Dictionary<DamageType, List<string>> Dtypes
	{
		get => this.damageTypes;
	}

	public string Immune
	{
		get => (this.damageTypes != null) ? string.Join(", ", this.damageTypes[DamageType.Immune]) : string.Empty;
	}

	public string Resistant
	{
		get => (this.damageTypes != null) ? string.Join(", ", this.damageTypes[DamageType.Resistant]) : string.Empty;
	}

	public string Vulnerable
	{
		get => (this.damageTypes != null) ? string.Join(", ", this.damageTypes[DamageType.Vulnerable]) : string.Empty;
	}
}
