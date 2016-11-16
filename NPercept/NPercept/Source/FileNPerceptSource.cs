using System;
using System.IO;
using System.Threading.Tasks;
using NPercept.Language;

namespace NPercept.Source
{
	public class FileNPerceptSource
	{
		public class FileNPerceptSource : NPerceptSource
		{
			protected int actualDocumentId = 0;

			public void Process(string[] a_paths)
			{
				StreamReader reader;
				Document document;

				foreach (var path in a_paths)
				{
					reader = new StreamReader(path);
					document = new Document(reader.ReadToEnd(), ref m_words, this.WordRegister, Languages.French);
					m_documents.Add(actualDocumentId++, document);
					reader.Close();
					int total = 0;
					object lockObjectWords = new Object();
					object lockObjectRelations = new Object();
					Parallel.For(0, document.Words.Count, i =>
						//for (int i = 0; i < document.Words.Count; i++)
						{
							//document.Words.ElementAt(i) = stemmer.Stem(document.Words.ElementAt(i));
							Console.WriteLine(total);
							Word word = document.Words.ElementAt(i);

							lock (lockObjectWords)
							{
								if (!m_words.ContainsKey(word.Id))
								{
									m_words.Add(word.Id, document.Words.ElementAt(i));
								}
							}

							DocumentRelation relation = new DocumentRelation(actualDocumentId, word.Id);

							lock (lockObjectRelations)
							{
								if (!m_relations.ContainsKey(relation))
								{
									m_relations.Add(relation, 1);
								}
								else m_relations[relation] = (int)m_relations[relation] + 1;

							}
							total++;
						});
				}
			}

			public FileNPerceptSource() : base()
			{

			}
		}
	}
}

