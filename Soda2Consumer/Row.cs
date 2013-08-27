using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Soda2Consumer
{
    public class Row : Dictionary<string, object> 
    {
        public Row() { }
        public Row(Dictionary<string,object> dictionary) : base(dictionary) { }
    }
}
