using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace DMTools;

public static class MarkupExtensions
{
	/// <summary>
	/// Causes the string to render as the given markup based on regex matches.
	/// </summary>
	/// <param name="original"> The string to markup. </param>
	/// <param name="regex"> The regex to match on. </param>
	/// <param name="start"> The beginning markup. For example "<i>" </param>
	/// <param name="end"> The ending markup. Foe example "</i>" </param>
	/// <returns></returns>
	public static MarkupString MarkupString(string original)
	{
		original = AddNewLines(@original);
		// matches italics and then bold. Need to add in list support (">")
		Regex[] regexes = [new Regex(@"_([^_]*)_"), new Regex(@"\*\*([^\*\*]*)\*\*"), new Regex(@"\#([^\#]*)")];
		int count = 0;
		string changed = string.Empty;

		foreach (Regex regex in regexes)
		{
			string start, end;
			switch (count)
			{
				case (0):
					start = "<i>";
					end = "</i>";
					break;
				case (1):
					start = "<b>";
					end = "</b>";
					break;
				case (2):
					start = "<li>";
					end = "</li>";
					break;
				default:
					start = end = string.Empty; 
					break;
			}
			foreach (Match match in regex.Matches(original))
			{
				// get rid of the stuffs
				string value = match.Groups[1].Value;
				value = start + value + end;
				original = original.Replace(match.Value, value);
			}

			count++;
		}
		return new MarkupString(original);
	}

	public static string AddNewLines(string original)
	{
		return Regex.Replace(original, @"\r\n?|\n", "<br />"); ;
	}
}
