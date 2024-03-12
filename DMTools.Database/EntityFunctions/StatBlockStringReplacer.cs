using DMTools.Database.Entities;
using DMTools.Shared.DiceCalculator;
using System.Text.RegularExpressions;

namespace DMTools.Database.Entities;

public static class StatBlockStringReplacer
{
    private static Regex regex = new Regex(@"\[([^\]]*)\]");
    public static string ReplaceBracketModifiers(string original, Stats stats, int profBonus, string shortenedName = "", string pluralName = "")
    {
        if (original == null)
            return string.Empty;

        original = ReplaceAngleBrackets(original);

        // general pattern
        // [MON] [MONS] is shorthand for the shortened/ plural names [done]
        // [CHA] [WIS] is the monsters stat modifier (charisma and wisdom here)
        // [STR ATK] [WIS ATK] is the modifier for an attack (strength or wisdom here)
        // [STR 1D10] [STR 1d10] calculates the damage roll for a strength based attack with 1d10 damage die
        // [3D6 + 1] [4d10 - 3] calculates the average roll plus the modifier given
        // [WIS SAVE] [CHA SAVE + 2] calculates the saving throw for the type of stat wis or cha in this case)
        // Length rules nothing out here ([CHA] vs [1D10])

        /*
         * Steps:
         * 1. Check for name 
         * 2. Check for atk vs save
         * 3. Check for raw throw
         * 4. Check for die roll (looking for a "d") 
         * 5. ???
         * 6. Profit
         * 
         */
        
        MatchCollection matches = regex.Matches(original);
        foreach (Match match in matches)
        {
            string value = (match.Groups[1].Success ? match.Groups[1].Value : "").ToLower();
            string total;

            // no value, just move on
            if (value == "")
                continue;
            
            // replaces mon and mons
            if (value.Contains("mon"))
            {
                // move on after this (helps keep code clean
                total = (value.Length == 3) ? shortenedName : pluralName;
            }
            // replace attack
            else if (value.Contains("atk"))
            {
                // get the string rep of the total
                total = GetValue(stats, value, profBonus, false);
            }
            // replace save
            else if (value.Contains("save"))
            {
                total = GetValue(stats, value, profBonus, true);
            }
            // check for raw throw
            else if (value.Contains("d") && !value.Contains("e"))
            {
                string[] roll = value.Split(" ");
                int dieIndex = 0;
                int addedMod = 0;

                // find the index of the dice
                if (roll[0].Contains("d"))
                {
                    dieIndex = 0;

                    // if there is an added modifier, add it to tthe average
                    if (roll.Length > 1)
                    {
                        addedMod = ParseInt(roll[2], roll[1]);
                    }
                }
                else
                {
                    dieIndex = 1;

                    // if there is an added modifier, add it to tthe average
                    if (roll.Length > 2)
                    {
                        addedMod = ParseInt(roll[3], roll[2]);
                    }
                }

                // create the dice object to get the average roll
                Dice die = new Dice(roll[dieIndex]);

                // if stat mod exists, add it to the avg roll
                int statMod = 0;
                if (dieIndex == 1)
                {
                    statMod = stats.GetAbilityMod(roll[0]);
                }

                total = die.GetDiceString(statMod + addedMod);
            }

            // raw ability mod
            else if (value.Length == 3)
            {
                int mod = stats.GetAbilityMod(value);
                total = string.Format("{0}{1}", ((mod >= 0) ? "+" : "-"), Math.Abs(mod));
            }
            // default
            else
            {
                total = match.Value;
            }

            original = original.Replace(match.Value, total);
        }

        return original;
    }

    private static int GetStatMod(Stats stats, string stat)
    {
        return stats.GetAbilityMod(stat);
    }

    private static string GetValue(Stats stats, string value, int profBonus, bool isSave)
    {
        // this gets rid of any null or empty values
        string[] values = value.Split(" ").Where(str => !string.IsNullOrEmpty(str)).ToArray<string>();
        // prof bonus is always added to attacks
        int statMod = GetStatMod(stats, values[0]) + profBonus;

        if (isSave)
            statMod += 8;

        // looking for modifier
        if (values.Length == 4)
        {
            int mod = ParseInt(values[3], values[2]);
            statMod += mod;
        }

        // get the string rep of the total
        string total = (isSave) ? statMod.ToString() : 
            string.Format("{0}{1}", ((statMod >= 0) ? "+" : "-"), Math.Abs(statMod));
        
        return total;
    }

    // parses out the int from the end of the array
    private static int ParseInt(string value, string sign)
    {
        if (!int.TryParse(value, out int mod))
            return 0;

        return mod * ((sign == "+") ? 1 : -1);
    }

    public static string ReplaceAngleBrackets(string original)
    {
        return original.Replace(">", "#");
    }
}
