using NPercept.Language;
using NPercept.Language.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NPercept.Lang;

namespace NPercept.Language.Document
{
    [DataContract]
    public class Sentence
    {
        [DataMember(Name = "words")]
        protected Word[] m_words;

        [DataMember(Name = "sentence")]
        protected string m_sentence;

        public Sentence(String a_sentence, WordSeparationMode a_mode)
        {
            this.m_sentence = a_sentence;
            this.m_words = Separate(a_sentence, a_mode);
        }

        public Sentence(String a_sentence)
        {
            this.m_sentence = a_sentence;
            this.m_words = Separate(a_sentence, WordSeparationMode.Space);
        }

        private static Word[] Separate(String a_sentence, WordSeparationMode a_mode)
        {
            switch (a_mode)
            {
                case WordSeparationMode.Space:
                    return a_sentence.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select((s) => new Word(s)).ToArray();

                default:
                    throw new NotImplementedException();
            }
        }

        public static List<Sentence> FromText(string a_text)
        {
            return FromText(a_text, TextSeparationMode.Dot);
        }

        public static List<Sentence> FromText(string a_text, TextSeparationMode a_mode)
        {
            switch (a_mode)
            {
                case TextSeparationMode.Dot:
                    return a_text.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).Select((s) => new Sentence(s)).ToList();

                default:
                    throw new NotImplementedException();
            }
        }

        public Word[] Words 
        {
            get {
                return m_words;
            }
        }
    }
}
