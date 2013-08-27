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

        public Dataset(DatasetProperties properties, string host, Soda2Client soda2Client)
        {
            this.domain = host;
            this.client = soda2Client;
            this.id = properties.id;
            this.name = properties.name;
            this.attribution = properties.attribution;
            this.attributionLink = properties.attributionLink;
            this.category = properties.category;
            this.createdAt = properties.createdAt;
            this.description = properties.description;
            this.downloadCount = properties.downloadCount;
            this.licenceId = properties.licenceId;
            this.rowsUpdatedAt = properties.rowsUpdatedAt;
            this.viewLastModified = properties.viewLastModified;
            this.columns = properties.columns;
        }
        public QueryResult<R> query(string q)
        {
            var response = client.get(Soda2Url.queryUri(domain, id, q));
            var rows = new QueryResult<R>(response.GetResponseStream(), columns);
            response.Close();
            return rows;            
        }

        public QueryResult<R> query(QueryBuilder qb) { return query(qb.ToString()); }

        public R getRow(string rowId)
        {
            var response = client.get(Soda2Url.rowUri(domain, id, rowId));
            var body = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var ser = new JavaScriptSerializer();
            var row = ser.Deserialize<R>(body);           
            response.Close();
            return row;
        }

        public string domain { get; protected set; }
        
        public string id { get; protected set; }
        
        public string name { get; protected set; }
        
        public string attribution { get; protected set; }
        
        public string attributionLink { get; protected set; }
        
        public string category { get; protected set; }
        
        public long createdAt { get; protected set; }
        
        public string description { get; protected set; }
        
        public long downloadCount { get; protected set; }
        
        public string licenceId { get; protected set; }
        
        public long rowsUpdatedAt { get; protected set; }
        
        public long viewLastModified { get; protected set; }
        
        public Column[] columns { get; protected set; }

        public Soda2Client client { get; protected set; }
    }
}
