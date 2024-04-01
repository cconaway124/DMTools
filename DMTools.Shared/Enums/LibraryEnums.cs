using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Shared.Enums;

public static class LibraryEnums
{
    public enum SizeEnum
    {
        None = -1,
        Tiny = 1,
        Small,
        Medium,
        Large,
        Huge,
        Gargantuan
    }

    public enum StatType
    {
        None = -1,
        Str = 0,
        Dex,
        Con,
        Int,
        Wis,
        Cha,
    }

	public enum DamageType
	{
		[Description("Damage Immunities")]
		Immune = 0,

		[Description("Damage Resistances")]
		Resistant = 1,

		[Description("Damage Vulnerabilities")]
		Vulnerable = 2,
	}

    public enum UserLoginType
    {
        [Description("User was found in the database.")]
        Found = 0,

        [Description("User was not found in the database.")]
        NotFound,

        [Description("Password was successfully entered.")]
        Success,

        [Description("Wrong password for user.")]
        WrongPassword,

    }

	public static StatType StrToStatType(string type)
    {
        switch (type.ToLower())
        {
            case "str":
                return StatType.Str;
            case "dex":
                return StatType.Dex;
            case "con":
                return StatType.Con;
            case "int":
                return StatType.Int;
            case "wis":
                return StatType.Wis;
            case "cha":
                return StatType.Cha;
            default:
                return StatType.None;
        }
    }

    public enum ActionType
    {
        [Description("None")]
        None = -1,

        [Description("Actions")]
        Action = 1,

        [Description("Bonus Actions")]
        BonusAction,

        [Description("Reactions")]
        Reactions,

        [Description("Legendary Actions")]
        Legendary,

        [Description("Mythic Actions")]
        Mythic,

        [Description("Lair Actions")]
        Lairs,

        [Description("Regional Effects")]
        Regionals,

        [Description("Abilities")]
        Abilities,
    }

    public static ActionType ActionStrToEnum(string action)
    {
        action = action.ToLower();
        switch (action)
        {
            case "actions":
                return ActionType.Action;

            case "bonus actions":
                return ActionType.BonusAction;

            case "reactions":
                return ActionType.Reactions;

            case "legendary actions":
                return ActionType.Legendary;

            case "mythic actions":
                return ActionType.Mythic;

            case "lair actions":
                return ActionType.Lairs;

            case "regional effects":
                return ActionType.Regionals;

            case "abilities":
                return ActionType.Abilities;
            default:
                return ActionType.None;
        }
    }

}
