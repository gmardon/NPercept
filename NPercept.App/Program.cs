using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace NPercept.App
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			List<string> documents_list = new List<string>();
			List<string> words_list = new List<string>();
			DenseMatrix<int> words_relations = new DenseMatrix<int> (1);
			

			string text = System.IO.File.ReadAllText(@"hugo_les_miserables.txt");
			string[] sentences = text.Split ('.');
			string[] words;
			int index = 0;
			int word_total = 0;
			foreach (string sentence in sentences) {
				Console.WriteLine ("Processing {0}/{1} with a total of {2} words, and {3} unique words", index, sentences.Length, word_total, words_list.Count);
				documents_list.Add (sentence);
				words = sentence.Split (' ');
				foreach (string word in words) {
					if (!words_list.Contains (word)) {
						words_list.Add (word.Replace(',', '\0').Trim ());
					}
					words_relations.
				}
				index++;
				word_total += words.Length;
			}

			//
		}
	}
}
