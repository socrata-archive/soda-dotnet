using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UnitTests.model
{
    class Crime
    {
        public int id { get; set; }
        public string case_number { get; set; }
        public string block { get; set; }
        public string primary_type { get; set; }
        public string location_description { get; set; }
        public string date { get; set; }
        public bool domestic { get; set; }
        public bool arrest { get; set; }
        public string description { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}
