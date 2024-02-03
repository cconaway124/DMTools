using System.ComponentModel;

namespace DMToolsLibrary.StatBlocks.StatBlockHelpers;

public class DamageTypes
{
	private List<string> immuneTo;
	private List<string> resistantTo;
	private List<string> vulnerableTo;

	public DamageTypes(Dictionary<string, string>[] dTypes)
	{
		immuneTo = new List<string>();
		resistantTo = new List<string>();
		vulnerableTo = new List<string>();

		foreach (Dictionary<string, string> dType in dTypes)
		{
			dType.TryGetValue("name", out string? name);
			dType.TryGetValue("type", out string? type);

			if (name == null || type == null)
				continue;

			if (type.ToLower() == DamageType.Immune.GetDescription())
			{
				immuneTo.Add(name);
			}
			else if (type.ToLower() == DamageType.Resistant.GetDescription())
			{
				resistantTo.Add(name);
			}
			else if (type.ToLower() == DamageType.Vulnerable.GetDescription())
			{
				vulnerableTo.Add(name);
			}
			else
				continue;
		}
	}

	public int ImmuneCount
	{
		get => this.immuneTo.Count;
	}

	public int ResistantCount
	{
		get => this.resistantTo.Count;
	}

	public int VulnerableCount
	{
		get => this.vulnerableTo.Count;
	}

	public string Immune
	{
		get => string.Join(", ", this.immuneTo);
	}

	public string Resistant
	{
		get => string.Join(", ", this.resistantTo);
	}

	public string Vulnerable
	{
		get => string.Join(", ", this.vulnerableTo);
	}
}
