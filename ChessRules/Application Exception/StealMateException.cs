
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChessRules
{
    [Serializable]
    public class StealMateException : ApplicationException
    {
        public StealMateException()
        {
        }

        public StealMateException(string message) 
            : base(message)
        {
        }

        public StealMateException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected StealMateException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
