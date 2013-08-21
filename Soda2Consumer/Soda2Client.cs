using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Soda2Consumer
{
    public class Soda2BasicAuthClient : Soda2Client
    {
        private string username;
        private string password;
        protected override WebRequest createWebRequest(Uri uri)
        {
            var wr = base.createWebRequest(uri);
            string authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            wr.Headers["Authorization"] = "Basic " + authInfo;
            wr.Headers["X-App-Token"] = "zjL32Qb0VxNaI9xEUeJezBEIL";
            return wr;
        }

        public Soda2BasicAuthClient(string username, string password)
        {
            // TODO: Complete member initialization
            this.username = username;
            this.password = password;
        }
    }

    public class Soda2Client
    {
        protected string appToken;

        
        
        public Soda2Client(string p)
        {
            this.appToken = p;
        }

        public Soda2Client()
        {
            
        }

        protected virtual WebRequest createWebRequest(Uri uri)
        {
            return WebRequest.Create(uri);
        }

        public WebResponse sendWebRequest(Uri uri)
        {
            var request = createWebRequest(uri);
            try
            {
                var response = request.GetResponse();
                return response;
            }
            catch (WebException e)
            {
                return e.Response;
            }
        }

        public Dataset<R> getDatasetInfo<R>(string host, string fourByFour)
        {
            var url = Soda2Url.metadataUrl(host, fourByFour);
            var response = sendWebRequest(url);
            string body = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var ser = new JavaScriptSerializer();
            var dataset = ser.Deserialize<Dataset<R>>(body);
            dataset.client = this;
            dataset.domain = host;
            return dataset;
        }
    }
}
