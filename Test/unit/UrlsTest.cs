using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soda2Consumer;

namespace UnitTests.unit
{
    [TestClass]
    public class UrlsTest
    {
        [TestMethod]
        public void dataUrlTest()
        {
            var url = Soda2Url.dataUrl("opendata.socrata.com", "qrqr-xi46", "select * limit 3");
            Assert.AreEqual("http://opendata.socrata.com/resource/qrqr-xi46.json?$query=select+*+limit+3", url);
        }
    }
}
