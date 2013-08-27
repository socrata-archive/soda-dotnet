using Soda2Consumer;
using Soda2Publisher;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SampleDataPublisherApp
{
    class PublisherApp
    {
        static void Main(string[] args)
        {
            string host = ConfigurationManager.AppSettings["socrata.host"];
            string datasetId = ConfigurationManager.AppSettings["socrata.sample.publishDataset"];
            string username = ConfigurationManager.AppSettings["socrata.username"];
            string password = ConfigurationManager.AppSettings["socrata.password"];
            var basicAuthClient = new Soda2BasicAuthClient(username, password);
            var dataset = basicAuthClient.getDatasetInfo<Row>(host, datasetId);

        }
    }
}
