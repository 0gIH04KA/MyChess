using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class SecondTestException : Exception
    {
        public SecondTestException()
        {
        }

        public SecondTestException(string message) : base(message)
        {
        }

        public SecondTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SecondTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
