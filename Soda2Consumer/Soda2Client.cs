using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CSharpSoda2Consumer
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
        public Dataset getDatasetInfo(string domain, string fourByFour)
        {
            var url = string.Format("http://{0}/views/{1}.json", domain, fourByFour);
            var request = WebRequest.Create(url);
            var response = request.GetResponse();
            var ser = new DataContractJsonSerializer(typeof(Dataset));
            var Dataset = (Dataset)ser.ReadObject(response.GetResponseStream());
            return Dataset;
        }
    }
}
