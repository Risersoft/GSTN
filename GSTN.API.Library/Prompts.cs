using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace GSTN.API
{

	class Prompts
	{
		private class KeywordPrompt
		{
			private string[] m_keywords;
			private string m_default;
			static Regex s_reg = new Regex(".*\\[(?<keywords>.*)\\]\\<(?<default>.*)\\>$");
			public KeywordPrompt(string prompt)
			{
				var match = s_reg.Match(prompt);
				if (!match.Success) {
					throw new ArgumentException();
				}
				m_keywords = match.Groups["keywords"].Value.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
				m_default = match.Groups["default"].Value;
				string dummy = null;
				if (string.IsNullOrEmpty(m_default) || !TryMatch(m_default, ref dummy)) {
					throw new ArgumentException();
				}
			}
			public bool TryMatch(string str, ref string match)
			{
				if (string.IsNullOrEmpty(str)) {
					match = m_default;
					return true;
				}
				match = null;
				var matches = m_keywords.Where(s => s.StartsWith(str, StringComparison.CurrentCultureIgnoreCase));
				if (matches.Count() != 1) {
					return false;
				}
				match = matches.First();
				return true;
			}
		}
		public static string PromptForKeyword(string promptString)
		{
			var prompt = new KeywordPrompt(promptString);
			while (true) {
				Console.Write("{0}:", promptString);
				var resp = Console.ReadLine();
				string ret = null;
				if (prompt.TryMatch(resp, ref ret)) {
					return ret;
				}
			}

		}
	}
}

