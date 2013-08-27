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

        public WebResponse get(Uri uri)
        {
            return sendWebRequest("GET", uri);
        }

        public WebResponse post(Uri uri, string body)
        {
            return sendWebRequest("POST", uri, body);
        }

        public WebResponse put(Uri uri, string body)
        {
            return sendWebRequest("PUT", uri, body);
        }

        public WebResponse delete(Uri uri)
        {
            return sendWebRequest("DELETE", uri);
        }

        protected WebResponse sendWebRequest(string method, Uri uri)
        {
            return sendWebRequest(method, uri, null);
        }

        protected WebResponse sendWebRequest(string method, Uri uri, string body)
        {
            var request = createWebRequest(uri);
            request.Method = method;
            

            if (body != null)
            {
                var bytes = new UTF8Encoding().GetBytes(body);
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
            }

            try
            {
                var response = request.GetResponse();
                return response;
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    var stream = wex.Response.GetResponseStream();
                    var exBody = new StreamReader(stream).ReadToEnd();
                    throw new SodaException(exBody, wex);
                }
                else 
                {
                    throw wex;
                }
            }
        }

        public Dataset<R> getDatasetInfo<R>(string host, string fourByFour)
        {
            var url = Soda2Url.metadataUri(host, fourByFour);
            var response = get(url);
            string body = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var ser = new JavaScriptSerializer();
            var properties = ser.Deserialize<DatasetProperties>(body);
            response.Close();
            return new Dataset<R>(properties, host, this);
        }
    }
}
