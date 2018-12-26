using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Canducci.ZipCodePostmon.Internals;
using System.Threading.Tasks;
using System.Net;
using Canducci.ZipCodePostmon;
namespace UnitTestZipCode
{

    [TestClass]
    public class UnitTest1
    {
        internal ZipCodeRequest ZipCodeRequest { get; set; }
        internal ZipCodeResult ZipCodeResult { get; set; }

        public UnitTest1()
        {
            ZipCodeRequest = ZipCodeRequest.Create();
            ZipCodeResult = ZipCodeResult.Create();
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

        [TestMethod]        
        public void TestZipCodeResultGetReturnZipCode()
        {
            ZipCode zipCode = ZipCodeResult.Find(new ZipCodeNumber("01.414-000"));
            Assert.IsInstanceOfType(zipCode, typeof(ZipCode));
        }

        [TestMethod]
        public void TestZipCodeNumberTryParseSuccess()
        {
            bool status = ZipCodeNumber.TryParse("01414000", out ZipCodeNumber number);
            ZipCode zipCode = ZipCodeResult.Find(number);
            Assert.IsInstanceOfType(zipCode, typeof(ZipCode));
            Assert.IsTrue(status);
            Assert.IsInstanceOfType(number, typeof(ZipCodeNumber));
            Assert.AreEqual("01414000", number.Value);
            Assert.AreEqual("01414000", (string)number);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestZipCodeNumberTryParseError()
        {
            new ZipCodeNumber("", true);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestZipCodeNumberTryParseErrorExplicit()
        {
            var result = (ZipCodeNumber)"";
            Assert.Fail();
        }
    }
}
