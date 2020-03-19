using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class FirstTestException : Exception
    {
        public FirstTestException()
        {
        }

        public FirstTestException(string message) : base(message)
        {
        }

        public FirstTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FirstTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
