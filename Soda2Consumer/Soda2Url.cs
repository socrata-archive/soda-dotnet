using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Soda2Consumer
{
    public static class Soda2Url
    {
        public static Uri metadataUri(string domain, string fourByFour) 
        {
            return new Uri(string.Format("https://{0}/views/{1}.json", domain, fourByFour)); 
        }

        public static Uri datasetUri(string host, string fourByFour)
        {
            return new Uri(string.Format("https://{0}/resource/{1}.json", host, fourByFour));
        }

        public static Uri rowUri(string host, string fourByFour, string rowId)
        {
            return new Uri(string.Format("https://{0}/resource/{1}/{2}.json", host, fourByFour, HttpUtility.UrlEncode(rowId)));
        }

        public static Uri queryUri(string host, string fourByFour, string query) { 
            return new Uri(string.Format("https://{0}/resource/{1}.json?$query={2}", host, fourByFour, HttpUtility.UrlEncode(query))); 
        }
    }
}
