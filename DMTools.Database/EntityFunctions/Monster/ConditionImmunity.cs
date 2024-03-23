using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public partial class ConditionImmunity
{
	public ConditionImmunity() { }

	public static List<ConditionImmunity> CreateConditionImmunities(Dictionary<string, string>[] conditionImmunities)
	{
		List<ConditionImmunity> conditionImm = new();

        for (int i = 0; i < conditionImmunities.Length; i++)
        {
			conditionImm.Add(new ConditionImmunity { Description = conditionImmunities[i]["name"] });
        }

		return conditionImm;
    }

    public ConditionImmunity(Dictionary<string, string>[] conditionImmunities)
    {
		/*this.conditionImmunities = new string[conditionImmunities.Length];

		for (int i = 0; i < conditionImmunities.Length; i++)
		{
			this.conditionImmunities.Add(new ConditionImmunity { Description = conditionImmunities[i]["name"] });
        }*/
    }

	public override string ToString()
	{
		return this.Description;
	}
}
