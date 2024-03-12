using DMTools.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.StatBlocks.StatBlockHelpers;

public partial class ConditionImmunities
{
    [ForeignKey(name: "MonsterId")]
    public Monster Monster { get; set; }
    [ForeignKey(name: "ConditionImmunityId")]
    public ConditionImmunity ConditionImmunity { get; set; }
}
