using System;

namespace geiko.DZ_42.My_Exceptions
{
        public class PointCoincidenceException : ApplicationException
        {
            public PointCoincidenceException() { }

            public PointCoincidenceException(string message) : base(message) { }

            public PointCoincidenceException(string message, Exception inner) : base(message, inner) { }

            protected PointCoincidenceException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
}
