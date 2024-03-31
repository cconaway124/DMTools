using DMTools.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using static DMTools.Shared.Enums.LibraryEnums;

namespace DMTools.Database.Entities;

public partial class MonsterActions
{
    private ActionType actionName;
    private string actionDescription;
    private Dictionary<string, string> actions;

    public Dictionary<string, string> Actions
    {
        get => this.actions;
    }

    public MonsterActions() { }

    public MonsterActions(Dictionary<string, string>[] actions,
        ActionType actionType,
        string actionDescription,
        Stats stats,
        int profBonus,
        string shortenedName,
        string pluralName)
    {
        this.actionName = actionType;
        this.actionDescription = actionDescription;
        this.actions = this.ConvertToDict(actions);
        
        foreach (KeyValuePair<string, string> pair in this.actions)
        {
            //this.actions[pair.Key] = StatBlockStringReplacer.ReplaceAngleBrackets(pair.Value);
            this.actions[pair.Key] = StatBlockStringReplacer.ReplaceBracketModifiers(pair.Value, stats, profBonus, shortenedName, pluralName);
        }
    }

    public List<MonsterActions> ConvertToList()
    {
        List<MonsterActions> actions = new List<MonsterActions>();
        
        foreach (KeyValuePair<string, string> pair in this.Actions)
        {
            actions.Add(new MonsterActions
            {
                ActionName = this.actionName.GetDescription(),
                ActionDescription = pair.Value,
                Name = pair.Key,
                ActionType = (int)this.actionName,
            });
        }

        return actions;
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
