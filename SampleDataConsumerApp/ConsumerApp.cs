using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Soda2Consumer;
using CSharpSoda2;

namespace SampleDataConsumerApp
{
    class ConsumerApp
    {
        static void Main(string[] args)
        {
            var noAuthClient = new Soda2Client();

            var dataset = noAuthClient.getDatasetInfo<Row>("opendata.test-socrata.com", "qrqr-xi46");
            Column[] columns = dataset.columns;
            var responseA = dataset.query("select * where title = 'The Killer'");
            Console.Write(responseA);
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

            var basicAuthClient = new Soda2Client("name", "password");
            var oAuthClient = new Soda2Client("oauth app key");
        }
    }
}
