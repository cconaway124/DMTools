using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMToolsLibrary.Enums.LibraryEnums;

namespace DMToolsLibrary.StatBlocks.StatBlockHelpers
{
    public class Stats
    {
		private int[] statPoints;
        private int[] statMods;

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

        public int Str
        {
            get => this.statMods[(int)StatType.Str];
        }

        public int Dex
        {
            get => this.statMods[(int)StatType.Str];
        }

        public int Con
        {
            get => this.statMods[(int)StatType.Str];
        }

        public int Int
        {
            get => this.statMods[(int)StatType.Str];
        }

        public int Wis
        {
            get => this.statMods[(int)StatType.Str];
        }

        public int Cha
        {
            get => this.statMods[(int)StatType.Str];
        }

        private int CalculateAbilityMod(int points)
        {
            return (int)Math.Floor(((double)points - 10) / 2);
        }

        public string ToString(StatType type)
        {
            return string.Format("{0} ({1})", this.statPoints[(int)type], this.statMods[(int)type]);
        }
    }
}
