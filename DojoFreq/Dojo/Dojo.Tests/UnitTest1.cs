using System;

using NUnit.Framework;

namespace Dojo.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var c = new Class1();
            Assert.IsTrue(c != null);
        }
    }
}
