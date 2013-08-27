using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soda2Consumer;
using System.Configuration;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class HttpIntegrationTest
    {
        public static string host = ConfigurationManager.AppSettings["socrata.host"];
        public static string datasetId = ConfigurationManager.AppSettings["socrata.sample.privateDataset"];
        private static string username = ConfigurationManager.AppSettings["socrata.username"];
        private static string password = ConfigurationManager.AppSettings["socrata.password"];
        private static string appToken = ConfigurationManager.AppSettings["socrata.appToken"];
        public static Soda2Client noAuthClient = new Soda2Client(null,null,null);
        public static Soda2Client basicAuthClient = new Soda2Client(username, password, appToken);        

        [TestMethod]
        [ExpectedException(typeof(SodaException))]
        public void ConfirmDatasetPrivateTest()
        {
            Dataset<Row> shouldBePrivate = noAuthClient.getDatasetInfo<Row>(host, datasetId);
        }

        [TestMethod]
        public void BasicAuthTest()
        {
            Dataset<Row> dataset = basicAuthClient.getDatasetInfo<Row>(host, datasetId);
            Assert.IsNotNull(dataset.columns);
            Assert.IsNotNull(dataset.name);
        }
    }
}
