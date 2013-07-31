using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace CSharpSoda2Consumer
{
    [DataContract]
    public class Dataset
    {
        public QueryResult query(string p)
        {
            var request = WebRequest.Create(Urls.dataUrl(domain, id));
            var response = request.GetResponse();
            var result = new QueryResult(response.GetResponseStream());
            return result;
        }

        public string domain { get; set; }
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
