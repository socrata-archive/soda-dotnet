using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Soda2Consumer;

namespace UnitTests
{
    [TestClass]
    public class QueryResultTest
    {
        static FileStream crimeJson = File.OpenRead("resources/crime.json");
        static Column[] columns = null;
        QueryResult qr = new QueryResult(crimeJson, columns);

        [TestMethod]
        public void QueryResultConstructorTest()
        {
            Assert.IsTrue(crimeJson.Length > 0, "could not read file");
            Assert.IsNotNull(qr.rows, "QueryResult did not assign rows");
            Assert.IsTrue(qr.rows.Length > 0, "QueryResult did not create rows");
        }
    }
}
