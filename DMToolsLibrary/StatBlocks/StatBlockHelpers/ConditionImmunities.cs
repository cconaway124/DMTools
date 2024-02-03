using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.StatBlocks.StatBlockHelpers;

public class ConditionImmunities
{
	private string[] conditionImmunities;
    public ConditionImmunities(Dictionary<string, string>[] conditionImmunities)
    {
		this.conditionImmunities = new string[conditionImmunities.Length];

		for (int i = 0; i < conditionImmunities.Length; i++)
		{
			this.conditionImmunities[i] = conditionImmunities[i]["name"];
		}
    }

	public override string ToString()
	{
		return string.Join(", ", this.conditionImmunities);
	}
}
