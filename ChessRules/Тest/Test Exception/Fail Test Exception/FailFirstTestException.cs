using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class FailFirstTestException : Exception
    {
        public FailFirstTestException()
        {
        }

        public FailFirstTestException(string message) : base(message)
        {
        }

        public FailFirstTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailFirstTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
