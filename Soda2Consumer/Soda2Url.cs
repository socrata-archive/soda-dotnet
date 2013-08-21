using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Soda2Consumer
{
    public class Soda2Url
    {
        public static Uri metadataUrl(string domain, string fourByFour) { return new Uri(string.Format("https://{0}/views/{1}.json", domain, fourByFour)); }
        public static Uri dataUrl(string host, string fourByFour, string query) { 
            return new Uri(string.Format("https://{0}/resource/{1}.json?$query={2}", host, fourByFour, HttpUtility.UrlEncode(query))); 
        }
    }
}
