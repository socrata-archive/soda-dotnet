using System;
using Soda2Consumer;
using System.Configuration;
using NUnit.Framework;


namespace UnitTests
{
    [TestFixture]
    public class HttpIntegrationTest
    {
        public static string host = ConfigurationManager.AppSettings["socrata.host"];
        public static string datasetId = ConfigurationManager.AppSettings["socrata.sample.privateDataset"];
        private static string username = ConfigurationManager.AppSettings["socrata.username"];
        private static string password = ConfigurationManager.AppSettings["socrata.password"];
        public static Soda2Client noAuthClient = new Soda2Client();
        public static Soda2Client basicAuthClient = new Soda2BasicAuthClient(username, password);
        

        [Test]
        public void ConfirmDatasetPrivateTest()
        {
            Dataset<Row> shouldBePrivate = noAuthClient.getDatasetInfo<Row>(host, datasetId);
            Assert.IsTrue(shouldBePrivate.error, "request with no auth should cause error");
        }

        [Test]
        public void BasicAuthTest()
        {
            Dataset<Row> dataset = basicAuthClient.getDatasetInfo<Row>(host, datasetId);
            Assert.IsNotNull(dataset.columns);
            Assert.IsNotNull(dataset.name);
        }
    }
}
