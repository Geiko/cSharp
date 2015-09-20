using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geiko.DZ_54.Exceptions
{
    [Serializable]
    public class NoCardRecordException : ApplicationException
    {
        public NoCardRecordException() { }
        public NoCardRecordException(string message) : base(message) { }
        public NoCardRecordException(string message, Exception inner) : base(message, inner) { }
        protected NoCardRecordException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
