using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            var sut = new AzureTest();
            sut.test();
        }
    }
}
