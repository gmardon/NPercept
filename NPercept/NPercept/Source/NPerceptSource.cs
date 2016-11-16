using System;
using System.Collections.Generic;
using NPercept.Language;

namespace NPercept.Source
{
	public abstract class NPerceptSource
	{
		protected Dictionary<int, Document> m_documents;
		protected Dictionary<long, Word> m_words;
		protected Dictionary<DocumentRelation, int> m_relations;

		protected WordRegister m_wordRegister;

		public WordRegister WordRegister
		{
			get
			{
				return m_wordRegister;
			}
			set
			{
				this.m_wordRegister = value;
			}
		}

		public Dictionary<long, Word> Word
		{
			get
			{
				return m_words;
			}
			set
			{
				this.m_words = value;
			}
		}

		public NPerceptSource()
		{
			m_documents = new Dictionary<int, Document>();
			m_relations = new Dictionary<DocumentRelation, int>();
			m_words = new Dictionary<long, Word>();
			m_wordRegister = new BaseWordRegister();
		}
	}
}