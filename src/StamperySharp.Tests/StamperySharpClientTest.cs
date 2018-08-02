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
            var stamperyClient = new StamperySharpClient("d3e5a67964d6be0", "254b810c-6292-43b1-c5e5-59cda63bbf1f");
            var result = stamperyClient.Stamp("fa814e37ad092518b0b33ed1f21c8bac4daed663435abba01e369399522279e5");
            Assert.IsNotNull(result);
        }
    }
}
