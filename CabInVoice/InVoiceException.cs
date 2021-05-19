using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInVoice
{
     public class InvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }

        public ExceptionType type;
        
        public InvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
