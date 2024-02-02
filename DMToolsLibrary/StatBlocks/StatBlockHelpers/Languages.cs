using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMToolsLibrary.StatBlocks.StatBlockHelpers;

public class Languages
{
	private Dictionary<string, bool> languages;
	private string understandsBut;

	public Languages(Dictionary<string, string>[] languages, string understandsBut)
	{
		this.understandsBut = understandsBut;
		this.languages = new Dictionary<string, bool>();

		foreach (Dictionary<string, string> language in languages) {

		}
	}
}
