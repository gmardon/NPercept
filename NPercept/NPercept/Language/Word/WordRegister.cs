using NPercept.Language.Stemmer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPercept.Language.Word
{
    public interface WordRegister
    {
        Word Register(string a_text, IStemmer a_stemmer);
    }
}
