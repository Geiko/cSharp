using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geiko.DZ_54.Exceptions
{
    [Serializable]
    public class UnAvailableBookException : ApplicationException
    {
        public UnAvailableBookException() { }
        public UnAvailableBookException(string message) : base(message) { }
        public UnAvailableBookException(string message, Exception inner) : base(message, inner) { }
        protected UnAvailableBookException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
