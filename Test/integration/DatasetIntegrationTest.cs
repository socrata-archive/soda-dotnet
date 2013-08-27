using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soda2Consumer;
using System.Configuration;

namespace UnitTests.integration
{
    [TestClass]
    public class DatasetIntegrationTest
    {
        public static string host = ConfigurationManager.AppSettings["socrata.host"];
        public static string datasetId = ConfigurationManager.AppSettings["socrata.sample.dataset"];
        public static Soda2Client noAuthClient = new Soda2Client(null,null,null);
        public static Dataset<Row> dataset = noAuthClient.getDatasetInfo<Row>(host, datasetId);
        
        [TestMethod]
        public void datasetInfoTest() 
        {   
            Assert.IsNotNull(dataset.columns);
            Assert.IsNotNull(dataset.name);
        }

        [TestMethod]
        public void simpleQueryTest()
        {
            var qr = dataset.query("select *");
            Assert.IsNotNull(qr);
            Assert.IsTrue(qr.Length == 1000);
        }

        [TestMethod]
        public void complexQueryTest()
        {
            var qr = dataset.query("select id, description, location_description where primary_type = 'ASSAULT' limit 5 offset 5");
            Assert.IsNotNull(qr);
            Assert.IsTrue(qr.Length == 5);
        }
    }
}
