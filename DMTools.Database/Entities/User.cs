using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public class User
{
    [Key]
    public int UserId { get; set; }
    [MaxLength(50)]
    public string UserName { get; set; }
    [MaxLength(150)]
    public string UserEmail { get; set; }
    [MaxLength(50)]
    public string Password { get; set; }
    public Guid UserGuid { get; set; }
}
