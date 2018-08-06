using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StamperySharp.Tests
{
    [TestClass]
    public class StamperyClientTest
    {
        private const string ClientId = "your-client-id";
        private const string Secret = "your-secret";

        [TestMethod]
        public void StampTest()
        {
            var stamperyClient = new StamperyClient(ClientId, Secret);
            var result = stamperyClient.Stamp("fa814e22ad09251800b33ed1f22c8bac4daed663435abba01e369399522279e5");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var stamperyClient = new StamperyClient(ClientId, Secret);
            var result = stamperyClient.GetById("5b6353a32b5c4b0004c933a5");
            Assert.IsTrue(result.Result.Length != 0);
        }

        [TestMethod]
        public void GetOtsFileTest()
        {
            var stamperyClient = new StamperyClient(ClientId, Secret);
            var result = stamperyClient.GetOtsFile("5b6353a32b5c4b0004c933a5");
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetPdfFileTest()
        {
            var stamperyClient = new StamperyClient(ClientId, Secret);
            var result = stamperyClient.GetPdfFile("5b6353a32b5c4b0004c933a5");
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var stamperyClient = new StamperyClient(ClientId, Secret);
            var result = stamperyClient.GetAll();
            Assert.IsTrue(result.Result.Length != 0);
        }
    }
}