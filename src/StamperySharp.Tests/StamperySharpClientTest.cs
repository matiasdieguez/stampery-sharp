using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StamperySharp.Tests
{
    [TestClass]
    public class StamperySharpClientTest
    {
        [TestMethod]
        public void StampTest()
        {
            var stamperyClient = new StamperySharpClient("your-client-id", "your-secret");
            var result = stamperyClient.Stamp("fa814e37ad092518b0b33ed1f21c8bac4daed663435abba01e369399522279e5");
            Assert.IsNotNull(result);
        }
    }
}
