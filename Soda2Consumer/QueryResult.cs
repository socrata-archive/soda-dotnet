using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace Soda2Consumer
{
    public class QueryResult
    {
        private Column[] columns;
        public Row[] rows { get; private set; }

        public QueryResult(Stream stream, Column[] columns)
        {
            var body = new StreamReader(stream).ReadToEnd();
            Console.Write(body);
            var ser = new JavaScriptSerializer();
            var rowObjects = (object[])ser.DeserializeObject(body);

        }
    }
}
