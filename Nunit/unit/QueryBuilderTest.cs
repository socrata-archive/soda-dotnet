using System;
using Soda2Consumer;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class QueryBuilderTest
    {
        [Test]
        public void SimpleQueryTest()
        {
            var qb = new QueryBuilder().select("title", "year");
            Assert.AreEqual("select title, year", qb.ToString());
        }

        [Test]
        public void ComplicatedQueryTest()
        {
            var qb = new QueryBuilder()
            .select("year", "count(year)")
            .where("year > 1950")
            .groupBy("year")
            .having("count_year > 0")
            .orderBy("count_year desc")
            .offset(4)
            .limit(5);
            Assert.AreEqual("select year, count(year) where year > 1950 group by year having count_year > 0 order by count_year desc offset 4 limit 5", qb.ToString());
        }
    }
}
