using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soda2Consumer
{
    public class SocrataException : Exception
    {
        public SocrataException(string message, Exception inner) : base(message, inner) {}
    }
}
