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

[Table(name: "Senses", Schema = "monster")]
public partial class Senses
{
    [Key]
    public int SenseId { get; set; }
    public int? BlindSight { get; set; }
    public int? Darkvision { get; set; }
    public int? Tremorsense { get; set; }
    public int? Truesight { get; set; }
    public int? Telepathy { get; set; }
    public int PassivePerception { get; set; }
    [ForeignKey(name: "MonsterId")]
    public Monster Monster { get; set; }
}
