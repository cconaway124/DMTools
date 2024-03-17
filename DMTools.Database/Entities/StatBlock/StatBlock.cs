using DMTools.Shared.DiceCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public abstract class StatBlock
{
    public string Name { get; set; }

    public SizeEnum Size { get; set; }

    public AC ArmorClass { get; set; }

    public int HitPoints { get; set; }

    public HitDie HitDie { get; set; }

    public int Speed { get; set; }

    public Stats Stats { get; set; }

    public Senses Senses { get; set; }

    public string Alignment { get; set; }

    public Speeds Speeds { get; set; }

    public Languages Languages { get; set; }
}
