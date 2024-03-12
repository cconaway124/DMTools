using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DMTools.Shared.Enums;

namespace DMTools.StatBlocks.StatBlockHelpers;

public partial class Senses
{
    private string[] senses;
    private bool blind;

    private enum SightType {
        [Description("blindsight")]
        blindsight = 0,

        [Description("darkvision")]
        darkvision,

        [Description("tremorsense")]
        tremorsense,

        [Description("truesight")]
        truesight,

        [Description("telepathy")]
        telepathy,

        [Description("passive Perception")]
        passive_perception
    }

    public Senses(
        string blindsight,
        bool blind,
        string darkvision,
        string tremorsense,
        string truesight,
        string telepathy,
        string passivePerc)
    {
        senses = new string[]
        {
            blindsight,
            darkvision,
            tremorsense,
            truesight,
            telepathy,
            passivePerc
        };

        this.blind = blind;
    }

    public override string ToString()
    {
        StringBuilder senseStr = new StringBuilder();
        for (int i = 0; i < this.senses.Length; i++)
        {
            string senseDist = this.senses[i];

            if (senseDist == "0")
            {
                continue;
            }

            if (i != 0 && i != 1)
            {
                senseStr.Append(", ");
            }

            string sense = ((SightType)i).GetDescription();

            senseStr.Append(sense + " " + senseDist + ((sense != "passive Perception") ? "ft." : ""));

            if (sense == "blindvision" && blind)
            {
                senseStr.Append(" (blind beyond this radius)");
            }
        }

        return senseStr.ToString();
    }
}
