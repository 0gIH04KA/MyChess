using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    class FailStandartTestException : Exception
    {
        public FailStandartTestException()
        {
        }

        public FailStandartTestException(string message) : base(message)
        {
        }

        public FailStandartTestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FailStandartTestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
