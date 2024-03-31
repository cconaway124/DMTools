using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public partial class SavingThrows
{

    private Dictionary<StatType, int> stats;
    public SavingThrows() { }
    public SavingThrows(Dictionary<string, string>[] types, Stats stats, int profBonus)
    {
        StatType[] saveType = GetSaveTypes(types);
        this.stats = new Dictionary<StatType, int>();
        foreach (StatType statType in saveType)
        {
            this.stats[statType] = stats.GetAbilityMod(statType) + profBonus;
        }

        this.SetSavingThrows();
    }

    public void SetSavingThrows()
    {
        foreach (KeyValuePair<StatType, int> pair in this.stats)
        {
            switch (pair.Key)
            {
                case (StatType.Str):
                    this.Str = pair.Value;
                    break;

                case (StatType.Dex):
                    this.Dex = pair.Value;
                    break;

                case (StatType.Con):
                    this.Con = pair.Value;
                    break;

                case (StatType.Int):
                    this.Int = pair.Value;
                    break;

                case (StatType.Wis):
                    this.Wis = pair.Value;
                    break;

                case (StatType.Cha):
                    this.Cha = pair.Value;
                    break;

                default: break;
            }
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

    public void SetStats()
    {
		if (this.stats == null)
		{
			this.stats = new Dictionary<StatType, int>();
			if (this.Str != null)
			{
				this.stats.Add(StatType.Str, this.Str ?? 0);
			}

			if (this.Dex != null)
			{
				this.stats.Add(StatType.Dex, this.Dex ?? 0);
			}

			if (this.Con != null)
			{
				this.stats.Add(StatType.Con, this.Con ?? 0);
			}

			if (this.Int != null)
			{
				this.stats.Add(StatType.Int, this.Int ?? 0);
			}

			if (this.Wis != null)
			{
				this.stats.Add(StatType.Wis, this.Wis ?? 0);
			}

			if (this.Cha != null)
			{
				this.stats.Add(StatType.Cha, this.Cha ?? 0);
			}
		}
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
