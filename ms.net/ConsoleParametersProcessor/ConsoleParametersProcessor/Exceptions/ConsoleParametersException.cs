using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleParametersProcessor.Exceptions
{
    public class ConsoleParametersException : Exception
    {
        public ConsoleParametersException(string message)
            : base(message)
        {
        }
              
    }

    // Duplicated keys
    // Duplicated alias
    // Not founded key/alias
    // Unrecognized key
}
