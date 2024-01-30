using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.StatBlocks.StatBlockHelpers;

public class MonsterActions
{
    private string actionName;
    private string actionDescription;

    /// <summary>
    /// This is your "Legendary Action", "Action", etc.
    /// </summary>
    public string ActionName
    { 
        get => this.actionName; 
        set => this.actionName = value; 
    }

    public string ActionDescription
    {
        get => this.actionDescription;
        set => this.actionDescription = value;
    }

    public Dictionary<string, string> ActionDict { get; set; }

    public MonsterActions(Dictionary<string, string>[] actions, string actionName, string actionDescription)
    {
        this.actionName = actionName;
        this.actionDescription = actionDescription;
        this.ConvertToDict(actions);
    }

    private Dictionary<string, string> ConvertToDict(Dictionary<string, string>[] dicts)
    {
        Dictionary<string, string> joinedDict = new Dictionary<string, string>();
        foreach(Dictionary<string, string> dict in dicts)
        {
            // dicts should only have 2 keys "name" and "desc"
            if (dict.Keys.Count() != 2) continue;

            string key, value;
            foreach (string val in dict.Keys)
            {
                
            }
        }
        return null;
    }
}
