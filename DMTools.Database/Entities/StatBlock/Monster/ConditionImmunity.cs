﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

[Table(name: "ConditionImmunity", Schema = "monster")]
public partial class ConditionImmunity
{
	[Key]
	public int ConditionImmunityId { get; set; }
	public string Description { get; set; }
    [ForeignKey(name: "MonsterId")]
    public virtual Monster? Monster { get; set; }
}
