using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using NPercept.Language;

namespace NPercept.Source
{
	public class FileNPerceptSource : NPerceptSource
	{
		protected int actualDocumentId = 0;

		public void Process (string[] a_paths)
		{
			StreamReader reader;
			Document document;

			foreach (var path in a_paths) {
				reader = new StreamReader (path);
				document = new Document (reader.ReadToEnd (), this.WordRegister, Languages.French);				
			}
			Console.WriteLine ("processed {0} uniques words!", this.WordRegister.Words.Count);
		}

		public FileNPerceptSource () : base ()
		{

		}
	}
}