using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Shared.DiceCalculator;
{
    public class HitDie
    {
        private int numHitDie;
        private string hitDie;
        private string conMod;
        private int avgHp;

        public HitDie(int numHitDie, SizeEnum size, int conMod)
        {
            this.numHitDie = numHitDie;
            (this.hitDie, int dieSize) = this.SetHitDie(size);
            this.conMod = this.SetConMod(conMod, numHitDie);
            this.avgHp = this.CalculateAvgHp(numHitDie, dieSize, conMod);
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
            return string.Format(
                "{0} ({1}{2}{3})",
                this.avgHp,
                this.numHitDie,
                this.hitDie,
                this.conMod);
        }
    }
}
