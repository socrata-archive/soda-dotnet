using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Soda2Consumer;
using UnitTests.model;

namespace UnitTests
{
    [TestClass]
    public class QueryResultTest
    {
        FileStream crimeJson = File.OpenRead("resources/crime.json");
        Column[] columns = null;
        
        protected void testResultDeserialization<R>(R[] rows)
        {
            Assert.IsTrue(crimeJson.Length > 0, "could not read file");
            Assert.IsNotNull(rows, "did not assign rows");
            Assert.IsTrue(rows.Length > 0, "QueryResult did not create rows");
            Assert.IsTrue(rows.Length == 999, "QueryResult did not create all the rows");
        }

        [TestMethod]
        public void QueryResultConstructorWithRowClassTest()
        {
            var rows = Soda2Client.deserialize<Row[]>(crimeJson);
            testResultDeserialization(rows);
        }

        [TestMethod]
        public void QueryResultWithModelClassTest()
        {
            var rows = Soda2Client.deserialize<Crime[]>(crimeJson);
            testResultDeserialization(rows);
        }

        [TestMethod]
        public void QueryResultWithObjectClassTest()
        {
            var rows = Soda2Client.deserialize<Object[]>(crimeJson);
            testResultDeserialization(rows);
        }
    }
}
