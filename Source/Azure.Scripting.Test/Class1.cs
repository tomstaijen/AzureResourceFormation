using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Scripting.Test
{
    [TestFixture]
    public class Test 
    {
        [Test]
        public void TestUseOfGlobalsProperty()
        {
            var x = new Azure.Scripting.Class1()
            {
                A = 4
            }.Add("5").Result;

            Assert.AreEqual(9, x, "Addition failed");
        }

        [Test]
        public void TestUseOfGlobalsMethod()
        {
            var x = new Azure.Scripting.Class1()
            {
                A = 4
            }.Add("One()").Result;


            Assert.AreEqual(5, x, "Addition failed");
        }
    }
}
