using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NPercept.Language.Stemmer;
using NPercept.Language.French;
using NPercept.Language.English;
using System.Diagnostics;
using NPercept.Language;

namespace NPercept.Language
{
	[DataContract]
	public class Document
	{
		protected static Regex WORD_REGEX = new Regex ("([ \\t{}():;. \n])");
		protected IStemmer m_stemmer;

		[DataMember]
		protected LinkedList<Word> m_words;

		[DataMember]
		protected string m_text;

		public Document (string a_text, WordRegister a_register, Languages a_lang = Languages.English)
		{
			this.m_stemmer = GetStemmerByLanguage (a_lang);
			this.m_text = a_text;
			this.m_words = new LinkedList<Word> ();

			string[] words = WORD_REGEX.Split (a_text);

			char[] bothSidesTrimChar = {
				'\'',
				'«',
				'»',
				'<',
				'>',
				'/',
				':',
				';',
				'"',
				'{',
				'}',
				'|',
				'\\',
				'[',
				']',
				'.',
				',',
				'~',
				'`',
				'!',
				'?',
				'@',
				'#',
				'%',
				'^',
				'&',
				'*',
				'(',
				')',
				'_',
				'-',
				'+',
				'='
			};
			char[] endTrimChar = { '$' };
			for (int i = 0; i < words.Length; i++) {
				MatchCollection match = WORD_REGEX.Matches (words [i]);
				if (match.Count <= 0 && words [i].Trim ().Length > 0) {
					string word = (words [i]);
					word = word.Trim ();
					word = word.Trim (bothSidesTrimChar);
					word = word.TrimEnd (endTrimChar);
					word = word.Trim ();

					if (word != "")
						m_words.AddLast (a_register.Register (word, m_stemmer));
					
					Console.WriteLine (i + "/" + words.Length + " : " + word);
				}

			}

		}

		public LinkedList<Word> Words {
			get {
				return m_words;
			}
		}

		public string Text {
			get {
				return m_text;
			}
		}

		private static IStemmer GetStemmerByLanguage (Languages language)
		{
			switch (language) {
			case Languages.Czech:
				break;
			case Languages.English:
				return new EnglishStemmer ();
			case Languages.French:
				return new FrenchStemmer ();
			case Languages.Dutch:
				break;
			case Languages.Danish:
				break;
			case Languages.Finnish:
				break;
			case Languages.German:
				break;
			case Languages.Spanish:
				break;
			case Languages.Italian:
				break;
			case Languages.Norwegian:
				break;
			case Languages.Portugal:
				break;
			case Languages.Russian:
				break;
			case Languages.Hyngarian:
				break;
			case Languages.Romanian:
				break;
			default:
				break;
			}
			return null;
		}
	}
}
