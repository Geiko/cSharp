using System;

namespace geiko.DZ_42.My_Exceptions
{
    [Serializable]
    public class NotParallelSidesException : ApplicationException
    {
        public NotParallelSidesException() { }
        public NotParallelSidesException(string message) : base(message) { }
        public NotParallelSidesException(string message, Exception inner) : base(message, inner) { }
        protected NotParallelSidesException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
