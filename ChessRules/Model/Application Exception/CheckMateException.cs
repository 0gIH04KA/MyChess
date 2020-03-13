using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    [Serializable]
    public class CheckMateException : ApplicationException
    {
        public CheckMateException()
        {
        }

        public CheckMateException(string message) 
            : base(message)
        {
        }

        public CheckMateException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected CheckMateException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
