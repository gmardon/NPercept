using NPercept.Language.Stemmer;
using NPercept.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPercept.Language;

namespace NPercept.Language
{
    public class BaseWordRegister : WordRegister
    {
        protected Dictionary<long, Word> m_words;
        private int m_actualId = 0;

        public BaseWordRegister()
        {
            this.m_words = new Dictionary<long, Word>();
        }

        public Word Register(string a_text, IStemmer a_stemmer)
        {
            Word word = null;
            var root = a_stemmer.Stem(a_text);
            if (m_words.Any((w) => w.Value.Root == root))
            {
                word = m_words.First((w) => w.Value.Root == root).Value;
            }
            else
            {
                word = new Word(m_actualId++, a_text, a_stemmer);
                m_words.Add(word.Id, word);
            }
            return word;
        }
    }
}
