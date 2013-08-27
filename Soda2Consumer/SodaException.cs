using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soda2Consumer
{
    public class SodaException : Exception
    {
        public SodaException(string message, Exception inner) : base(message, inner) {}
    }
}
