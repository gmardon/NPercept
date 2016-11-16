using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NPercept.Lang.Word
{
    [DataContract]
    public struct WordRelation
    {
        [DataMember]
        private long m_sourceUid;

        [DataMember]
        private long m_destinationUid;

        [DataMember]
        private double m_indice;

        public long Destination
        {
            get
            {
                return m_destinationUid;
            }
            set
            {
                this.m_destinationUid = value;
            }
        }

        public long Source
        {
            get
            {
                return m_sourceUid;
            }
            set
            {

                this.m_sourceUid = value;
            }
        }
        public double Indice
        {
            get
            {
                return m_indice;
            }
            set
            {
                this.m_indice = value;
            }
        }

        public WordRelation(long a_source, long a_destination, int a_indice)
        {
            this.m_sourceUid = a_source;
            this.m_destinationUid = a_destination;
            this.m_indice = a_indice;
        }
    }
}
