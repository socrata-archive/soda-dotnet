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
        public string appToken { get; set; }
        public string username { get; set; }
        public string password { private get; set; }

        public Soda2Client(string username, string password, string appToken) 
        {
            this.username = username;
            this.password = password;
            this.appToken = appToken;
        }

        protected virtual WebRequest createWebRequest(Uri uri)
        {
            var wr = WebRequest.Create(uri);
            if (username != null && password != null)
            {
                string authInfo = username + ":" + password;
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                wr.Headers["Authorization"] = "Basic " + authInfo;
            }
            if (appToken != null)
            {
                wr.Headers["X-App-Token"] = "zjL32Qb0VxNaI9xEUeJezBEIL";
            }
            return wr;
        }

        public B getAndRead<B>(Uri uri)
        {
            return sendGetAndRead<B>(uri);
        }

        public void post(Uri uri, string body)
        {
            sendWebRequest("POST", uri, body);
        }

        public void put(Uri uri, string body)
        {
            sendWebRequest("PUT", uri, body);
        }

        public void delete(Uri uri)
        {
            sendWebRequest("DELETE", uri);
        }

        protected void sendWebRequest(string method, Uri uri)
        {
            sendWebRequest(method, uri, null);
        }

        protected void sendWebRequest(string method, Uri uri, string body)
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
                using (var response = request.GetResponse()) { }
            }
            catch (WebException wex) { throw tryReadSodaException(wex); }
        }

        protected B sendGetAndRead<B>(Uri uri)
        {
            var request = createWebRequest(uri);
            request.Method = "GET";

            try
            {
                using (var response = request.GetResponse()) 
                { 
                    var thing = deserialize<B>(response.GetResponseStream());
                    return thing;
                }
            }
            catch (WebException wex) { throw tryReadSodaException(wex); }
        }

        public Exception tryReadSodaException(WebException wex){
            if (wex.Response != null)
            {
                var stream = wex.Response.GetResponseStream();
                var exBody = new StreamReader(stream).ReadToEnd();
                return new SodaException(exBody, wex);
            }
            else
            {
                return wex;
            }
        }

        public static R deserialize<R>(Stream stream)
        {
            var body = new StreamReader(stream).ReadToEnd();
            var ser = new JavaScriptSerializer();
            var thing = ser.Deserialize<R>(body);
            return thing;
        }

        public R getRow<R>(string host, string fourByFour, string rowId)
        {
            return getAndRead<R>(Soda2Url.rowUri(host, fourByFour, rowId));
        }

        public Dataset<R> getDatasetInfo<R>(string host, string fourByFour)
        {
            var url = Soda2Url.metadataUri(host, fourByFour);
            var properties = getAndRead<DatasetProperties>(url);
            return new Dataset<R>(properties, host, this);
        }
    }
}
