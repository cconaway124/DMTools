using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.DiceCalculator;

public class Dice
{
    private int sides;
    private int numDie;
    public Dice(string dice)
    {
        string[] die = dice.ToLower().Split("d");
        if (die.Length != 2)
        {
            throw new ArgumentException("The string was not castable to a Dice object");
        }

        if (!int.TryParse(die[0], out int numDie))
            throw new ArgumentNullException("The number of die could not be parsed out of the string.");

        this.numDie = numDie;

        if (!int.TryParse(die[1], out int sides))
            throw new ArgumentNullException("The sides of the die could not be parsed out of the string.");

        this.sides = sides;
    }

    public string GetDiceString(int mod)
    {
        int avgDieRoll = DiceFunctions.CalculateAverage(this.numDie, this.sides, mod);
        return string.Format("{0} ({1}d{2} + {3})", avgDieRoll, this.numDie, this.sides, mod);
    }
}
