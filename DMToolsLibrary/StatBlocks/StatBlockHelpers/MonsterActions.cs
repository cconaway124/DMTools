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
    private Dictionary<string, string> actions;

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

    public Dictionary<string, string> Actions
    {
        get => this.actions;
    }

    public MonsterActions(Dictionary<string, string>[] actions,
        string actionName,
        string actionDescription,
        Stats stats,
        int profBonus,
        string shortenedName,
        string pluralName)
    {
        this.actionName = actionName;
        this.actionDescription = actionDescription;
        this.actions = this.ConvertToDict(actions);
        
        foreach (KeyValuePair<string, string> pair in this.actions)
        {
            this.actions[pair.Key] = StatBlockStringReplacer.ReplaceBracketModifiers(pair.Value, stats, profBonus, shortenedName, pluralName);
            this.actions[pair.Key] = StatBlockStringReplacer.ReplaceAngleBrackets(pair.Value);
        }
    }

    // need to rethink this, but oh well
    private Dictionary<string, string> ConvertToDict(Dictionary<string, string>[] dicts)
    {
        Dictionary<string, string> joinedDict = new Dictionary<string, string>();
        foreach(Dictionary<string, string> dict in dicts)
        {
            // dicts should only have 2 keys "name" and "desc"
            if (dict.Keys.Count() % 2 != 0) continue;

            string key = string.Empty, value = string.Empty;
            int count = 0;
            foreach (string val in dict.Values )
            {
                if (count == 0) 
                    key = val;
                else if (count == 1)
                    value = val;

                count++;
            }

            joinedDict[key] = value;
        }
        return joinedDict;
    }
}
