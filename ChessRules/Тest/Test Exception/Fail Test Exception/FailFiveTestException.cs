using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class FailFiveTestException : Exception
    {
        public FailFiveTestException()
        {
        }

        public FailFiveTestException(string message) : base(message)
        {
        }

        public FailFiveTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailFiveTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
