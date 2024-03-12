using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.StatBlocks.StatBlockHelpers;

public partial class Languages
{
	private Dictionary<string, bool> languages;
	private string understandsBut;

	public Languages(Dictionary<string, string>[] languages, string understandsBut)
	{
		this.understandsBut = understandsBut;
		this.languages = new Dictionary<string, bool>();

		foreach (Dictionary<string, string> language in languages) {
			language.TryGetValue("name", out string? name);
			language.TryGetValue("speaks", out string? speaks);

			if (name == null || speaks == null)
				continue;

			this.languages[name] = this.ToBool(speaks);
		}
	}

	private bool ToBool(string convBool)
	{
		convBool = convBool.ToLower();
		
		if (convBool.StartsWith("t") || convBool == "true")
		{
			return true;
		}
		else if (convBool.StartsWith("f") || convBool == "false")
		{
			return false;
		}
		else
		{
			throw new ArgumentException("The given string was not convertible to boolean. Must be \"true\" or \"false\".");
		}
	}

	public int LanguageCount
	{
		get => this.languages.Count;
	}

	public override string ToString()
	{
		if (this.languages.Count == 0)
			return "-";

		StringBuilder sb = new StringBuilder();

		// seperate out the speaks and understands
		string[] speaks = this.languages.Where(val => val.Value).Select(val => val.Key).ToArray();
		string[] understands = this.languages.Where(val => !val.Value).Select(val => val.Key).ToArray();

		sb.Append(string.Join(", ", speaks));

		if (understands.Length == 0)
			return sb.ToString();

		sb.Append(" understands ");

		sb.Append(string.Join(", ", understands));
		sb.Append("but " + this.understandsBut);
		
		return sb.ToString();
	}
}
