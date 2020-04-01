using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class FailThridTestException : Exception
    {
        public FailThridTestException()
        {
        }

        public FailThridTestException(string message) : base(message)
        {
        }

        public FailThridTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailThridTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
