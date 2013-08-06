using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Soda2Consumer
{
    public class QueryResult<R>
    {
        private Column[] columns;
        public R[] rows { get; private set; }

        public QueryResult(Stream stream, Column[] columns)
        {
            var body = new StreamReader(stream).ReadToEnd();
            var ser = new JavaScriptSerializer();
            rows = ser.Deserialize<R[]>(body);           
        }
    }
}
