using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSoda2Consumer;
using CSharpSoda2;

namespace SampleDataConsumerApp
{
    class ConsumerApp
    {
        static void Main(string[] args)
        {
            var noAuthClient = new Soda2Client();
            var basicAuthClient = new Soda2Client("name", "password");
            var oAuthClient = new Soda2Client("oauth app key");
            var dataset = noAuthClient.getDatasetInfo("explore.data.gov", "644b-gaut");
            Column[] columns = dataset.columns;
            var responseA = dataset.query("select * where lastname = 'smith'");
            var responseB = dataset.query(
                new QueryBuilder()
                .select("firstname", "lastname")
                .ToString()
            );
            var responseC = dataset.query(
                new QueryBuilder()
                .select("firstname", "lastname")
                .where("lastname = 'smith'")
                .groupBy()
                .having()
                .orderBy()
                .offset(5)
                .limit(5)
                .ToString()
            );
        }
    }
}
