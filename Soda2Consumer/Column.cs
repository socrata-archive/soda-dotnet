using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Soda2Consumer
{
    public class Column
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string dataTypeName { get; set; }
        [DataMember]
        public string fieldName { get; set; }

    }
}
