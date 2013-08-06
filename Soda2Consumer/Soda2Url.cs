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
        public static string metadataUrl(string domain, string fourByFour) { return string.Format("http://{0}/views/{1}.json", domain, fourByFour); }
        public static string dataUrl(string domain, string fourByFour, string query) { 
            return string.Format("http://{0}/resource/{1}.json?$query={2}", domain, fourByFour, HttpUtility.UrlEncode(query)); 
        }
    }
}
