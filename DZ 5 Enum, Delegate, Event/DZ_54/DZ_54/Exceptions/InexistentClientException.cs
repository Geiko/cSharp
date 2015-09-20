using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geiko.DZ_54.Exceptions
{
    [Serializable]
    public class InexistentClientException : ApplicationException
    {
        public InexistentClientException() { }
        public InexistentClientException(string message) : base(message) { }
        public InexistentClientException(string message, Exception inner) : base(message, inner) { }
        protected InexistentClientException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
