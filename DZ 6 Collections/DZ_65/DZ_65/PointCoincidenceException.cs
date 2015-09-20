using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geiko.DZ_65
{
    [Serializable]
    public class PiontCoincidenceException : ApplicationException
    {
        public PiontCoincidenceException() { }
        public PiontCoincidenceException(string message) : base(message) { }
        public PiontCoincidenceException(string message, Exception inner) : base(message, inner) { }
        protected PiontCoincidenceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
