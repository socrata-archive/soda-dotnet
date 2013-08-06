using Soda2Consumer;
using Soda2Publisher;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataPublisherApp
{
    class PublisherApp
    {
        static void Main(string[] args)
        {
            var basicAuthClient = new Soda2Client("name", "password");
            var host = ConfigurationManager.AppSettings["socrata.host"];
            var datasetId = ConfigurationManager.AppSettings["socrata.sample.dataset"];
            var dataset = basicAuthClient.getDatasetInfo<Row>(host, datasetId);
            
            dataset.truncate();

            Row row = new Row();

            dataset.addRow(row);
            dataset.deleteRow(row);
            dataset.updateRow(row);
            dataset.replaceRow(row);

            Row[] rowsToUpsert = new Row[]{new Row()};
            dataset.upsert(rowsToUpsert);
        }
    }
}
