using DMTools.Database.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;
public partial class HitDie
{
    private int numHitDie;
    private string hitDieType;
    private string conMod;
    private int avgHp;

    public HitDie() { }

    public HitDie(int numHitDie, SizeEnum size, int conMod)
    {
        this.numHitDie = numHitDie;
        var tuple = this.SetHitDie(size);
        this.hitDieType = tuple.Item1;
        int dieSize = tuple.Item2;
        this.conMod = this.SetConMod(conMod, numHitDie);
        this.avgHp = this.CalculateAvgHp(numHitDie, dieSize, conMod);

        this.HitDieType = SetHitDie(size).Item1;
        this.AverageHp = this.avgHp;
        this.ConMod = this.conMod;
        this.Count = this.numHitDie;
    }

    private (string, int) SetHitDie(SizeEnum size)
    {
        switch (size)
        {
            case SizeEnum.Tiny:
                return ("d4", 4);
            case SizeEnum.Small:
                return ("d6", 6);
            case SizeEnum.Medium:
                return ("d8", 8);
            case SizeEnum.Large:
                return ("d10", 10);
            case SizeEnum.Huge:
                return ("d12", 12);
            case SizeEnum.Gargantuan:
                return ("d20", 20);
            default:
                return ("d6", 6);
        }
    }

    private string SetConMod(int conMod, int hitDie)
    {
        long totalMod = conMod * hitDie;
        string sign = (totalMod >= 0) ? "+" : "-";
        return string.Format(" {0} {1}", sign, Math.Abs(totalMod));
    }

    private int CalculateAvgHp(int numHitDie, int dieSize, int conMod)
    {
        return (int)Math.Floor(numHitDie * ((double)(dieSize + 1) / 2.0) + (numHitDie * conMod));
    }

    public override string ToString()
    {
        if (avgHp == 0)
        {
            this.avgHp = this.AverageHp;
            this.numHitDie = this.Count;
            this.hitDieType = this.HitDieType;
            this.conMod = this.ConMod;
        }

        return string.Format(
            "{0} ({1}{2}{3})",
            this.avgHp,
            this.numHitDie,
            this.hitDieType,
            this.conMod);
    }
}

