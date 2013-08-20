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
        protected override WebRequest createWebRequest(string url)
        {
            var wr = base.createWebRequest(url);
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

        protected virtual WebRequest createWebRequest(String url)
        {
            return WebRequest.Create(url);
        }
        public Dataset<R> getDatasetInfo<R>(string domain, string fourByFour)
        {
            var url = Soda2Url.metadataUrl(domain, fourByFour);
            var request = createWebRequest(url);
            string body;
            try
            {
                var response = request.GetResponse();
                body = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response) 
                {
                    body = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
            }
            var ser = new JavaScriptSerializer();
            var dataset = ser.Deserialize<Dataset<R>>(body);
            dataset.domain = domain;
            return dataset;
        }
    }
}
