﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public partial class SavingThrows
{
    [Key]
    public int SavingThrowId { get; set; }
    public int ProfBonus { get; set; }
    public int? Str { get; set; }
    public int? Dex { get; set; }
    public int? Con { get; set; }
    public int? Int { get; set; }
    public int? Wis { get; set; }
    public int? Cha { get; set; }
    public string Name { get; set; }
    [ForeignKey(name: "MonsterId")]
    public virtual Monster Monster { get; set; }
}
