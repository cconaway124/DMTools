using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.Enums;

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
}
