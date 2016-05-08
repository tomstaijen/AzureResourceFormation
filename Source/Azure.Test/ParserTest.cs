using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Dsl;
using NUnit.Framework;
using Sprache;

namespace Azure.Test
{
    [TestFixture]
    public class ParserTest
    {
        [TestCase("hello", "hello")]
        [TestCase("a b", "a")]
        [TestCase("a123 xbz", "a123")]
        [TestCase("a_123 pietje", "a_123")]
        [TestCase("123 pietje", "123")]
        public void IdentifierTest(string input, string expected)
        {
            var identifier = Parser.Identifier.Parse(input);
            Assert.AreEqual(expected, identifier.Name);
        }

        public void fromSelectType()
        {
            var x = 
               from s in Parse.Decimal
                select s;
        }
    }
}
