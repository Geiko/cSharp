using System;

namespace geiko.DZ_42.My_Exceptions
{
    [Serializable]
    public class NoRightAngleException : ApplicationException
    {
        public NoRightAngleException() { }
        public NoRightAngleException(string message) : base(message) { }
        public NoRightAngleException(string message, Exception inner) : base(message, inner) { }
        protected NoRightAngleException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
