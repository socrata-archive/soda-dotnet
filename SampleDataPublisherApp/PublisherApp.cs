using Soda2Consumer;
using Soda2Publisher;
using System;
using System.Collections.Generic;
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
            var dataset = basicAuthClient.getDatasetInfo<Row>("opendata.test-socrata.com", "q9fc-4m3d");

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
