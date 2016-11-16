using NPercept.Language.French;
using NPercept.Language.Stemmer;
using NPercept.Language.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NPercept.Language.Word
{
    public class Word
    {
        protected readonly long m_uid;
        protected string m_root;
        protected string m_text;
        protected List<WordRelation> m_relations;

        public string Root
        {
            get
            {
                return this.m_root;
            }
            set 
            {
                this.m_root = value;
            }
        }

        public string Text
        {
            get
            {
                return this.m_text;
            }
            set
            {
                this.m_text = value;
            }
        }

        public long Id
        {
            get
            {
                return this.m_uid;
            }
        }

        public List<WordRelation> Relation
        {
            get
            {
                return this.m_relations;
            }
            set
            {
                this.m_relations = value;
            }
        }

        public Word(long a_uid)
        {
            this.m_uid = a_uid;
        }

        public Word(long a_uid, string a_text, string a_root) : this(a_uid)
        {
            this.m_text = a_text;
            this.m_root = a_root;
            this.m_relations = new List<WordRelation>();
        }

        public Word(long a_uid, string a_text, IStemmer a_stemmer)
            : this(a_uid, a_text, a_stemmer.Stem(a_text))
        {
        }

        public void AddRelation(Word a_target, int a_indice)
        {
            this.AddRelation(new WordRelation(m_uid, a_target.m_uid, a_indice));
        }

        public void AddRelation(WordRelation a_relation)
        {
            this.m_relations.Add(a_relation);
        }
    }
}
