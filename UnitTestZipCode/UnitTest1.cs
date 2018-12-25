using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Canducci.ZipCodePostmon.Internals;
using System.Threading.Tasks;
using System.Net;

namespace UnitTestZipCode
{
    [TestClass]
    public class UnitTest1
    {
        internal ZipCodeRequest ZipCodeRequest { get; set; }

        public UnitTest1()
        {
            ZipCodeRequest = ZipCodeRequest.Create();
        }

        [TestMethod]
        public void TestZipCodeGetJson()
        {
            string json = ZipCodeRequest.GetJson("01414000");              
            Assert.IsNotNull(json);
        }

        [TestMethod]
        public async Task TestZipCodeGetJsonAsync()
        {
            string json = await ZipCodeRequest.GetJsonAsync("01414000");
            Assert.IsNotNull(json);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void TestZipCodeGetJsonException404()
        {
            string json = ZipCodeRequest.GetJson("");
            Assert.Fail();
        }
    }
}
