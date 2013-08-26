using System;
using Soda2Consumer;
using System.Configuration;
using NUnit.Framework;

namespace UnitTests.integration
{
    [TestFixture]
    public class DatasetIntegrationTest
    {
        public static string host = ConfigurationManager.AppSettings["socrata.host"];
        public static string datasetId = ConfigurationManager.AppSettings["socrata.sample.dataset"];
        public static Soda2Client noAuthClient = new Soda2Client();
        public static Dataset<Row> dataset = noAuthClient.getDatasetInfo<Row>(host, datasetId);
        
        [Test]
        public void noopIntegrationTest()
        {
        }

        [Test]
        public void datasetInfoTest() 
        {   
            Assert.IsNotNull(dataset.columns);
            Assert.IsNotNull(dataset.name);
        }

        [Test]
        public void simpleQueryTest()
        {
            var qr = dataset.query("select *");
            Assert.IsNotNull(qr.rows);
            Assert.IsTrue(qr.rows.Length == 1000);
        }

        [Test]
        public void complexQueryTest()
        {
            var qr = dataset.query("select id, description, location_description where primary_type = 'ASSAULT' limit 5 offset 5");
            Assert.IsNotNull(qr.rows);
            Assert.IsTrue(qr.rows.Length == 5);
        }
    }
}
