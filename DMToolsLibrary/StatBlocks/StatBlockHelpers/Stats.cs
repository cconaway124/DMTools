using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.StatBlocks.StatBlockHelpers
{
    public class Stats
    {
		private int[] statPoints;

		private enum StatType
		{
			Str = 0,
			Dex,
			Con,
			Int,
			Wis,
			Cha,
		}

		public Stats(int str, int dex, int con, int inte, int wis, int cha)
		{
			this.statPoints = new int[]
			{
				str, dex, con, inte, wis, cha,
			};
		}

		public int Str
        {
            get => this.statPoints[(int)StatType.Str];
        }

		public int Dex
		{
            get => this.statPoints[(int)StatType.Dex];
        }

		public int Con
		{
            get => this.statPoints[(int)StatType.Con];
        }

		public int Int
		{
            get => this.statPoints[(int)StatType.Int];
        }

		public int Wis
		{
            get => this.statPoints[(int)StatType.Wis];
        }

		public int Cha
		{
            get => this.statPoints[(int)StatType.Cha];
        }
	}
}
