using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public partial class Stats
{
    private int[] statPoints;
    private int[] statMods;

    public Stats() { }

    public Stats(string str, string dex, string con, string inte, string wis, string cha)
        : this(ParseInt(str), ParseInt(dex), ParseInt(con), ParseInt(inte), ParseInt(wis), ParseInt(cha))
    {
    }

    public Stats(int str, int dex, int con, int inte, int wis, int cha)
    {
        this.statPoints = new int[]
        {
                str, dex, con, inte, wis, cha,
        };

        this.statMods = new int[this.statPoints.Length];

        for (int i = 0; i < this.statPoints.Length; i++)
        {
            this.statMods[i] = this.CalculateAbilityMod(this.statPoints[i]);

        }
    }

    public int StrPoints
    {
        get => this.statPoints[(int)StatType.Str];
    }

    public int DexPoints
    {
        get => this.statPoints[(int)StatType.Dex];
    }

    public int ConPoints
    {
        get => this.statPoints[(int)StatType.Con];
    }

    public int IntPoints
    {
        get => this.statPoints[(int)StatType.Int];
    }

    public int WisPoints
    {
        get => this.statPoints[(int)StatType.Wis];
    }

    public int ChaPoints
    {
        get => this.statPoints[(int)StatType.Cha];
    }

    /*public int Str
    {
        get => this.statMods[(int)StatType.Str];
    }

    public int Dex
    {
        get => this.statMods[(int)StatType.Dex];
    }

    public int Con
    {
        get => this.statMods[(int)StatType.Con];
    }

    public int Int
    {
        get => this.statMods[(int)StatType.Int];
    }

    public int Wis
    {
        get => this.statMods[(int)StatType.Wis];
    }

    public int Cha
    {
        get => this.statMods[(int)StatType.Cha];
    }*/

    private int CalculateAbilityMod(int points)
    {
        return (int)Math.Floor(((double)points - 10) / 2);
    }

    public string ToString(StatType type)
    {
        int stat = this.statMods[(int)type];
        string sign = (stat >= 0) ? "+" : "-";
        return string.Format("{0} ({1}{2})", this.statPoints[(int)type], sign, Math.Abs(stat));
    }

    public int GetAbilityMod(StatType type)
    {
        if (type == StatType.None) return 0;
        return this.statMods[(int)type];
    }

    public int GetAbilityMod(string type)
    {
        StatType stat = StrToStatType(type.ToLower());
        return GetAbilityMod(stat);
    }

    private static int ParseInt(string num)
    {
        if (num == null)
        {
            return 0;
        }

        if (int.TryParse(num, out int val))
        {
            return val;
        }

        return 0;
    }
}
