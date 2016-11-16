using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPercept.Language
{
    public struct DocumentRelation
    {
        private int m_documentId;
        private long m_wordId;

        public DocumentRelation(int a_documentId, long a_wordId)
        {
            this.m_documentId = a_documentId;
            this.m_wordId = a_wordId;
        }

        public int DocumentId
        {
            get
            {
                return m_documentId;
            }
            set
            {
                m_documentId = DocumentId;
            }
        }

        public long WordId
        {
            get
            {
                return m_wordId;
            }
            set
            {
                this.m_wordId = value;
            }
        }
    }
}
