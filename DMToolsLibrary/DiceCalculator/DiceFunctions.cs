using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.DiceCalculator;

public static class DiceFunctions
{
    public static int CalculateAverage(int numDie, int sides, int mod)
    {
        return (int)Math.Ceiling(numDie * ((double)(sides + 1) / 2.0) + mod);
    }
}
