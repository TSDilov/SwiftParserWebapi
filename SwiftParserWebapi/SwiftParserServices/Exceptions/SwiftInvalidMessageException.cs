using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftParserServices.Exceptions
{
    public class SwiftInvalidMessageException : Exception
    {
        public SwiftInvalidMessageException(string message) : base(message)
        {

        }
    }
}
