using DMTools.Database.Entities;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMTools.Database.Entities;

public partial class Languages
{
    private Dictionary<string, bool> languages;
    private string understandsBut;

    public Languages() { }

    public Languages(Dictionary<string, string>[] languages, string understandsBut)
    {
        this.understandsBut = understandsBut;
        this.languages = new Dictionary<string, bool>();

        foreach (Dictionary<string, string> language in languages)
        {
            language.TryGetValue("name", out string? name);
            language.TryGetValue("speaks", out string? speaks);

            if (name == null || speaks == null)
                continue;

            this.languages[name] = this.ToBool(speaks);
        }
    }

    public Languages(string name, int languageLevel)
    {
        this.LanguageName = name;
        this.LanguageLevel = languageLevel;
    }

    public List<Languages> ConvertToList()
    {
        List<Languages> list = new List<Languages>();
        foreach (KeyValuePair<string, bool> pair in this.languages)
        {
            list.Add(new Languages { LanguageName = pair.Key, LanguageLevel = (pair.Value) ? 1 : 0, UnderstandsBut = this.understandsBut });
        }

        return list;
    }

    private bool ToBool(string convBool)
    {
        convBool = convBool.ToLower();

        if (convBool.StartsWith("t") || convBool == "true")
        {
            return true;
        }
        else if (convBool.StartsWith("f") || convBool == "false")
        {
            return false;
        }
        else
        {
            throw new ArgumentException("The given string was not convertible to boolean. Must be \"true\" or \"false\".");
        }
    }

    public int LanguageCount
    {
        get => this.languages.Count;
    }

    public override string ToString()
    {
        if (this.languages.Count == 0)
            return "-";

        StringBuilder sb = new StringBuilder();

        // seperate out the speaks and understands
        string[] speaks = this.languages.Where(val => val.Value).Select(val => val.Key).ToArray();
        string[] understands = this.languages.Where(val => !val.Value).Select(val => val.Key).ToArray();

        sb.Append(string.Join(", ", speaks));

        if (understands.Length == 0)
            return sb.ToString();

        sb.Append(" understands ");

        sb.Append(string.Join(", ", understands));
        sb.Append("but " + this.understandsBut);

        return sb.ToString();
    }

    public static string ToString(IEnumerable<Languages> languages)
    {
        StringBuilder sb = new StringBuilder();
        int count = 0;
        foreach (Languages language in languages.Where(lang => lang.LanguageLevel > 0))
        {
            if (count == 0)
                sb.Append(language.LanguageName + ", ");
            else
                sb.Append(", " + language.LanguageName);
        }

        var understandsBut = languages.FirstOrDefault(lang => lang.LanguageLevel == 0);

        if (understandsBut == null)
        {
            return sb.ToString();
        }

        sb.Append($" {understandsBut.UnderstandsBut} ");
        count = 0;
        foreach (Languages language in languages.Where(lang => lang.LanguageLevel == 0))
        {
            if (count == 0)
                sb.Append(language.LanguageName + ", ");
            else
                sb.Append(", " + language.LanguageName);
        }

        return sb.ToString();
    }
}
