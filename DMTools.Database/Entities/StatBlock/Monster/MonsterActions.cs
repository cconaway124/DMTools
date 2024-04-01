using DMTools.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

[Table(name: "MonsterActions", Schema = "monster")]
public partial class MonsterActions
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MonsterActionId { get; set; }
    /// <summary>
    /// This is your "Legendary Action", "Action", etc.
    /// </summary>
    public string ActionName
    {
        get => this.actionName.GetDescription();
        set => this.actionName = ActionStrToEnum(value);
    }

    public string ActionDescription
    {
        get => this.actionDescription;
        set => this.actionDescription = value;
    }
    public string Name { get; set; }
    public int ActionType { get; set; }
    [ForeignKey(name: "Monster")]
    public int MonsterId { get; set; }
    public virtual Monster Monster { get; set; }
}
