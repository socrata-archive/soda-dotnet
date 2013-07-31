using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace CSharpSoda2Consumer
{
    public class QueryResult
    {
        private System.IO.Stream stream;
        public QueryResult(Stream stream)
        {
            this.stream = stream;
            var body = new StreamReader(stream).ReadToEnd();
            Console.Write(body);
            var ser = new JavaScriptSerializer();
            rows = (object[])ser.DeserializeObject(body);
        }

        //public object[] rows { get { return _rows; } }
        public object[] rows { get; private set; }
    }
}
