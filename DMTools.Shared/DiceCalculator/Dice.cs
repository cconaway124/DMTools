namespace DMTools.Shared.DiceCalculator;

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
            numDie = 1;

        this.numDie = numDie;

        if (!int.TryParse(die[1], out int sides))
            throw new ArgumentNullException("The sides of the die could not be parsed out of the string.");

        this.sides = sides;
    }

    public string GetDiceString(int mod)
    {
        int avgDieRoll = DiceFunctions.CalculateAverage(this.numDie, this.sides, mod);
        string sign = string.Empty;
        if (mod > 0)
            sign = " + ";
        else if (mod < 0) 
            sign = " - ";
        
        return string.Format("{0} ({1}d{2}{3}{4})", avgDieRoll, this.numDie, this.sides, sign, (mod == 0) ? "" : Math.Abs(mod));
    }

    public int GetAverageRoll(int mod)
    {
        return DiceFunctions.CalculateAverage(this.numDie, this.sides, mod);
    }
}
