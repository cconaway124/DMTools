﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public partial class Speeds
{
    [Key]
    public int SpeedId { get; set; }
    public int? Speed { get; set; }
    public int? Burrow { get; set; }
    public int? Climb { get; set; }
    public int? Fly { get; set; }
    public int? Swim { get; set; }
    public int? Hover { get; set; }
    [ForeignKey(name: "MonsterId")]
    public Monster Monster { get; set; }
}