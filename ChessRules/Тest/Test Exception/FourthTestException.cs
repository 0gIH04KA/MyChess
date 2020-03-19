using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class FourthTestException : Exception
    {
        public FourthTestException()
        {
        }

        public FourthTestException(string message) : base(message)
        {
        }

        public FourthTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FourthTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
