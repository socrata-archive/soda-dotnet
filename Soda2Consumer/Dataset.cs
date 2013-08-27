using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace Soda2Consumer
{
    
    public class Dataset<R>
    {
        public QueryResult<R> query(string q)
        {
            var response = client.get(Soda2Url.queryUri(domain, id, q));
            var rows = new QueryResult<R>(response.GetResponseStream(), columns);
            return rows;
        }

        public QueryResult<R> query(QueryBuilder qb) { return query(qb.ToString()); }

        public string domain { get; set; }
        
        public string id { get; set; }
        
        public string name { get; set; }
        
        public string attribution { get; set; }
        
        public string attributionLink { get; set; }
        
        public string category { get; set; }
        
        public long createdAt { get; set; }
        
        public string description { get; set; }
        
        public long downloadCount { get; set; }
        
        public string licenceId { get; set; }
        
        public long rowsUpdatedAt { get; set; }
        
        public long viewLastModified { get; set; }
        
        public Column[] columns { get; set; }

        //present in error response
        public string code { get; set; }

        //indicates error
        public bool error { get; set; }

        //present in error response
        public string message { get; set; }

        public Soda2Client client { get; set; }
    }
}
