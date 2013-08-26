using System;
using System.IO;
using Soda2Consumer;
using NUnit.Framework;
using UnitTests.model;

namespace UnitTests
{
    [TestFixture]
    public class QueryResultTest
    {
        FileStream crimeJson = File.OpenRead("resources/crime.json");
        Column[] columns = null;
        
        protected void testResultDeserialization<R>(QueryResult<R> qr)
        {
            Assert.IsTrue(crimeJson.Length > 0, "could not read file");
            Assert.IsNotNull(qr.rows, "QueryResult did not assign rows");
            Assert.IsTrue(qr.rows.Length > 0, "QueryResult did not create rows");
            Assert.IsTrue(qr.rows.Length == 999, "QueryResult did not create all the rows");
        }

        [Test]
        public void QueryResultConstructorWithRowClassTest()
        {
            QueryResult<Row> qr = new QueryResult<Row>(crimeJson, columns);
            testResultDeserialization(qr);
        }

        [Test]
        public void QueryResultWithModelClassTest()
        {
            QueryResult<Crime> qr = new QueryResult<Crime>(crimeJson, columns);
            testResultDeserialization(qr);
        }

        [Test]
        public void QueryResultWithObjectClassTest()
        {
            QueryResult<Object> qr = new QueryResult<Object>(crimeJson, columns);
            testResultDeserialization(qr);
        }
    }
}
