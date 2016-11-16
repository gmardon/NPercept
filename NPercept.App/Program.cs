using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPercept.App
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<string> documents_list = new List<string>();
			Object lockDocument = new Object();
			List<string> words_list = new List<string>();
			Object lockWord = new Object();
			string text = System.IO.File.ReadAllText(@"hugo_les_miserables.txt");
			string[] sentences = text.Split ('.');
			string[] words;
			int index = 0;
			int word_total = 0;
			Parallel.ForEach (sentences, sentence => {
				Console.WriteLine ("Processing {0}/{1} with a total of {2} words, and {3} unique words", index, sentences.Length, word_total, words_list.Count);
				lock(lockDocument) {
					documents_list.Add (sentence);
				}
				words = sentence.Split (' ');
				lock(lockWord) {
					foreach (string word in words) {
						if (!words_list.Contains (word)) {
							words_list.Add (word.Trim ());
						}
					}
				}
				index++;
				word_total += words.Length;
			});

			Matrix<int> words_relations;
		}
	}
}
