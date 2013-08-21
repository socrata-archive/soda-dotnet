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
            Console.WriteLine(String.Format("The Killer was directed by {0}", responseA.rows[0]["director"]));

            var responseB = dataset.query(
                new QueryBuilder()
                .select("count(year)", "year")
                .where("year > 1950")
                .groupBy("year")
                .having("count_year > 0")
                .orderBy("count_year desc")
            );
            Console.WriteLine(
                String.Format("This dataset shows {1} movies from {0}", 
                responseB.rows[1]["year"], 
                responseB.rows[1]["count_year"])
            );
        }
    }
}
