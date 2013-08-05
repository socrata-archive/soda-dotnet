using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soda2Consumer
{
    class Urls
    {
        public static string metadataUrl(string domain, string fourByFour) { return string.Format("http://{0}/views/{1}.json", domain, fourByFour); }
        public static string dataUrl(string domain, string fourByFour) { return string.Format("http://{0}/resource/{1}.json", domain, fourByFour); }
    }
}
