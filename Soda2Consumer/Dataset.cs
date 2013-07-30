using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CSharpSoda2Consumer
{
    [DataContract]
    public class Dataset
    {
        public QueryResult query(string p)
        {
            throw new NotImplementedException();
        }

        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string attribution { get; set; }
        [DataMember]
        public string attributionLink { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public long createdAt { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public long downloadCount { get; set; }
        [DataMember]
        public string licenceId { get; set; }
        [DataMember]
        public long rowsUpdatedAt { get; set; }
        [DataMember]
        public long viewLastModified { get; set; }
        [DataMember]
        public Column[] columns { get; set; }
    }
}
