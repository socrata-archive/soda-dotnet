using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soda2Consumer;
using System.Configuration;

namespace SampleDataConsumerApp
{
    class ConsumerApp
    {
        static void Main(string[] args)
        {
            var noAuthClient = new Soda2Client();
            var host = ConfigurationManager.AppSettings["socrata.host"];
            var datasetId = ConfigurationManager.AppSettings["socrata.sample.dataset"];
            var dataset = noAuthClient.getDatasetInfo<Row>(host, datasetId);
            Column[] columns = dataset.columns;
            var responseA = dataset.query("select * where title = 'The Killer'");
            Console.Write(String.Format("The movie was directed by {0}", responseA.rows[0]["director"]));

            var responseB = dataset.query(
                new QueryBuilder()
                .select("title", "year")
                .ToString()
            );
            var responseC = dataset.query(
                new QueryBuilder()
                .select("title", "year")
                .where("year > 1970")
                .groupBy()
                .having()
                .orderBy()
                .offset(5)
                .limit(5)
                .ToString()
            );

            var basicAuthClient = new Soda2BasicAuthClient("name", "password");
            var oAuthClient = new Soda2Client("oauth app key");
        }
    }
}
