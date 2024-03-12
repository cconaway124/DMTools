using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public partial class Stats
{
    [Key]
    public int StatId { get; set; }
    public int Str { get; set; }
    public int Dex { get; set; }
    public int Con { get; set; }
    public int Int { get; set; }
    public int Wis { get; set; }
    public int Cha { get; set; }
    [ForeignKey(name: "MonsterId")]
    public Monster Monster { get; set; }
}
