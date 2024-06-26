﻿using DMTools.Database.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

[Table(name: "DamageTypes", Schema = "monster")]
public partial class DamageTypes
{
	[Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DamageTypeId { get; set; }
	public int Type { get; set; }
	public string Description { get; set; }
    [ForeignKey(name: "Monster")]
    public int MonsterId { get; set; }
    public virtual Monster Monster { get; set; }
}
