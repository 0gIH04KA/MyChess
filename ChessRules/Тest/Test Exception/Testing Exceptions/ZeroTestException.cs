using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class ZeroTestException : Exception
    {
        public ZeroTestException()
        {
        }

        public ZeroTestException(string message) : base(message)
        {
        }

        public ZeroTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ZeroTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
