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
    public string UserName { get; set; } = string.Empty;
    [MaxLength(150)]
    public string UserEmail { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Password { get; set; } = string.Empty;
    public Guid UserGuid { get; set; }
}
