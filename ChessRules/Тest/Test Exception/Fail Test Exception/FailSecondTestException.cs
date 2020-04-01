using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class FailSecondTestException : Exception
    {
        public FailSecondTestException()
        {
        }

        public FailSecondTestException(string message) : base(message)
        {
        }

        public FailSecondTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailSecondTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
