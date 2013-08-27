using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Soda2Consumer;
using Soda2Publisher;
using System.IO;
using System.Web.Script.Serialization;

namespace UnitTests.integration
{
    [TestClass]
    public class PublishTest
    {
        public static string host = ConfigurationManager.AppSettings["socrata.host"];
        public static string datasetId = ConfigurationManager.AppSettings["socrata.sample.publishDataset"];
        private static string username = ConfigurationManager.AppSettings["socrata.username"];
        private static string password = ConfigurationManager.AppSettings["socrata.password"];
        public static Soda2Client basicAuthClient = new Soda2BasicAuthClient(username, password);
        public static Dataset<Row> dataset = basicAuthClient.getDatasetInfo<Row>(host, datasetId);

        [TestMethod]
        public void TestTruncateAndUpsert()
        {
            dataset.truncate();
            var resultA = dataset.query("select *");
            Assert.AreEqual(0, resultA.rows.Length, "rows present after truncate");

            FileStream movieJson = File.OpenRead("resources/movies.json");
            var body = new StreamReader(movieJson).ReadToEnd();
            var ser = new JavaScriptSerializer();
            var movies = ser.Deserialize<Row[]>(body);
            dataset.upsert(movies);
            var resultB = dataset.query("select :id, title, year, director, country");
            Assert.IsTrue(resultB.rows.Length > 0, "no rows after upsert");

            dataset.truncate();
            var resultC = dataset.query("select *");
            Assert.AreEqual(0, resultC.rows.Length, "rows present after (second) truncate");
        }
        
        [TestMethod]
        public void TestRowOperations()
        {
            const string testRowQuery = "select :id, title, year where title = 'test-row'";
            var initialCheckResponse = dataset.query(testRowQuery);
            if (initialCheckResponse.rows.Length > 0) 
            {
                for (int i = 0; i < initialCheckResponse.rows.Length; i++) 
                {
                    dataset.deleteRow(initialCheckResponse.rows[i][":id"].ToString());
                }
                Assert.Fail("test rows already present. Invalid starting condition. Try to run again");
            }
            
            Row testRow = new Row();
            testRow.Add("title", "test-row");
            testRow.Add("year", 2013);

            dataset.addRow(testRow);
            var responseWithAddedRow = dataset.query(testRowQuery);
            Assert.AreEqual(1, responseWithAddedRow.rows.Length, "could not find row that should have been added");
            var testRowAfterAdd = responseWithAddedRow.rows[0];
            Assert.AreEqual(testRow["year"].ToString(), testRowAfterAdd["year"].ToString(), "received row year differs from added row");
            Assert.AreEqual(testRow["title"].ToString(), testRowAfterAdd["title"].ToString(), "received row year differs from added row");

            var rowId = testRowAfterAdd[":id"].ToString();
            testRow["year"] = 1983;
            dataset.updateRow(rowId, testRow);
            var testRowAfterUpdate = dataset.getRow(rowId);
            Assert.AreEqual(testRow["year"].ToString(), testRowAfterUpdate["year"].ToString(), "received row year differs from updated row");
            Assert.AreEqual(testRow["title"].ToString(), testRowAfterUpdate["title"].ToString(), "received row year differs from updated row");

            dataset.deleteRow(rowId);
            try
            {
                var testRowAfterDelete = dataset.getRow(rowId);
                Assert.Fail("row present after delete");
            }
            catch (SocrataException){}
        }
    }
}
