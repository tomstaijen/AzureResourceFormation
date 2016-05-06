using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace Azure.Dsl
{
    class Parser
    {
        public static readonly Parser<string> Identifier = Parse.Letter.AtLeastOnce().Text().Token();
    }
}
