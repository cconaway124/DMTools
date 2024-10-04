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
    public string Name { get; set; } = string.Empty;

    public SizeEnum Size { get; set; }

    public AC ArmorClass { get; set; } = new();

    public int HitPoints { get; set; }

    public HitDie? HitDie { get; set; }

    public int Speed { get; set; }

    public Stats Stats { get; set; } = new();

    public Senses Senses { get; set; } = new();

    public string Alignment { get; set; } = string.Empty;

    public Speeds Speeds { get; set; } = new();

    public ICollection<Languages> Languages { get; set; } = new List<Languages>();

    public StatBlock() { }
}
