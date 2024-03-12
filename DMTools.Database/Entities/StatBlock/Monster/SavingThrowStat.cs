using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public class SavingThrowStat
{
    public int SavingThrowStatId { get; set; }
    [ForeignKey(name: "SavinThrowId")]
    public virtual SavingThrows SavingThrow {  get; set; }
    public int SavingThrowBonus { get; set; }
}
