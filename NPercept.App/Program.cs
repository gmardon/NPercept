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
			string text = System.IO.File.ReadAllText(@"hugo_les_miserables.txt");
			string[] sentences = text.Split ('.');
			string[] words;
			foreach (string sentence in sentences) {
				documents_list.Add (sentence);
				words = sentence.Split (' ');
				foreach (string word in words) {
					if (!words_list.Exists (word)) {
						words_list.Add (word.Trim ());
					}
				}
			}

			Matrix<int> words_relations;
		}
	}
}
