using System;
using Soda2Consumer;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class UrlsTest
    {
        [Test]
        public void dataUrlTest()
        {
            var url = Soda2Url.dataUrl("opendata.socrata.com", "qrqr-xi46", "select * limit 3");
            Assert.AreEqual(new Uri("https://opendata.socrata.com/resource/qrqr-xi46.json?$query=select+*+limit+3"), url);
        }
    }
}
