using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        get => (this.Str == 0) ? this.statPoints[(int)StatType.Str] : this.Str;
    }

    public int DexPoints
    {
        get => (this.Dex == 0) ?  this.statPoints[(int)StatType.Dex] : this.Dex;
    }

    public int ConPoints
    {
        get => (this.Con == 0) ? this.statPoints[(int)StatType.Con] : this.Con;
    }

    public int IntPoints
    {
        get => (this.Int == 0) ? this.statPoints[(int)StatType.Int] : this.Int;
    }

    public int WisPoints
    {
        get => (this.Wis == 0) ? this.statPoints[(int)StatType.Wis] : this.Wis;
    }

    public int ChaPoints
    {
        get => (this.Cha == 0) ? this.statPoints[(int)StatType.Cha] : this.Cha;
    }

    public int StrMod
    {
        get => this.CalculateAbilityMod(this.StrPoints);
    }

    public int DexMod
    {
        get => this.CalculateAbilityMod(this.DexPoints);
    }

    public int ConMod
    {
        get => this.CalculateAbilityMod(this.ConPoints);
    }

    public int IntMod
    {
        get => this.CalculateAbilityMod(this.IntPoints);
    }

    public int WisMod
    {
        get => this.CalculateAbilityMod(this.WisPoints);
    }

    public int ChaMod
    {
        get => this.CalculateAbilityMod(this.ChaPoints);
    }

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
