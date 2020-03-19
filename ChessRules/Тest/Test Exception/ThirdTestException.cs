using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class ThirdTestException : Exception
    {
        public ThirdTestException()
        {
        }

        public ThirdTestException(string message) : base(message)
        {
        }

        public ThirdTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ThirdTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
