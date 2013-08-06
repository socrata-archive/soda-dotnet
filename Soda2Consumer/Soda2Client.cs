using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Soda2Consumer
{
    public class Soda2Client
    {
        private string p1;
        private string p2;
        private string p;

        public Soda2Client(string p1, string p2)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
        }

        public Soda2Client(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public Soda2Client()
        {
            // TODO: Complete member initialization
        }
        public Dataset<R> getDatasetInfo<R>(string domain, string fourByFour)
        {
            var url = Urls.metadataUrl(domain, fourByFour);
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var ser = new JavaScriptSerializer();
            var body = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var dataset = ser.Deserialize<Dataset<R>>(body);
            dataset.domain = domain;
            return dataset;
        }
    }
}
