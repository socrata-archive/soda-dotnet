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
        public R[] query(string q)
        {
            return client.getAndRead<R[]>(Soda2Url.queryUri(domain, id, q));
        }

        public R[] query(QueryBuilder qb) { return query(qb.ToString()); }

        public R getRow(string rowId) { return client.getRow<R>(this.domain, this.id, rowId); }

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
