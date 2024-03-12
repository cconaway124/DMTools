using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.StatBlocks.StatBlockHelpers;

public partial class SavingThrows
{
    private Dictionary<StatType, int> stats;
    public SavingThrows(Dictionary<string, string>[] types, Stats stats, int profBonus)
    {
        StatType[] saveType = GetSaveTypes(types);
        this.stats = new Dictionary<StatType, int>();
        foreach (StatType statType in saveType)
        {
            this.stats[statType] = stats.GetAbilityMod(statType) + profBonus;
        }
    }

    private StatType[] GetSaveTypes(Dictionary<string, string>[] types)
    {
        List<StatType> saveTypes = new List<StatType>();
        foreach(Dictionary<string, string> type in types)
        {
            if (type.TryGetValue("name", out string save))
            {
                if (string.IsNullOrEmpty(save))
                    continue;

                StatType enumType = StrToStatType(save);
                if (enumType != StatType.None)
                {
                    saveTypes.Add(enumType);
                }
            }
        }

        return saveTypes.ToArray();
    }

    public Dictionary<StatType, int> Stats
    {
        get => this.stats;
    }

    public int GetSavingThrowBonus(StatType statType)
    {
        this.stats.TryGetValue(statType, out int value);
        return value;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        foreach (StatType type in this.stats.Keys)
        {
            if (count != 0)
                sb.Append(", ");

            int bonus = this.stats[type];
            string sign = (bonus >= 0) ? "+" : "-";
            sb.Append(string.Format("{0} {1}{2}", type, sign, bonus));
            count++;
        }

        return sb.ToString();
    }
}
