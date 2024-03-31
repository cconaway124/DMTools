using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DMTools.Shared.Enums;

namespace DMTools.Database.Entities;

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

    public Senses() { }

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
        this.SetSenses();
    }

    private void SetSenses()
    {
        for (int i = 0; i < this.senses.Length; i++)
        {
            bool val = int.TryParse(this.senses[i], out int a);
            switch ((SightType)i)
            {
                case SightType.blindsight:
                    this.BlindSight = val ? a : null;
                    break;

                case SightType.darkvision:
                    this.Darkvision = val ? a : null;
                    break;

                case SightType.tremorsense:
                    this.Tremorsense = val ? a : null;
                    break;

                case SightType.truesight:
                    this.Truesight = val ? a : null;
                    break;

                case SightType.telepathy:
                    this.Telepathy = val ? a : null;
                    break;

                case SightType.passive_perception:
                    this.PassivePerception = val ? a : 8;
                    break;

                default: break;
            }
        }
        this.Blind = this.blind;
    }

    public override string ToString()
    {
        if (this.senses == null)
        {
            this.senses = new string[]
            {
                (this.BlindSight ?? 0).ToString(),
                (this.Darkvision ?? 0).ToString(),
                (this.Tremorsense ?? 0).ToString(),
                (this.Truesight ?? 0).ToString(),
                (this.Telepathy ?? 0).ToString(),
                this.PassivePerception.ToString(),
            };

            this.blind = this.Blind;
        }

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

            if (sense == "blindvision" && this.blind)
            {
                senseStr.Append(" (blind beyond this radius)");
            }
        }

        return senseStr.ToString();
    }
}
