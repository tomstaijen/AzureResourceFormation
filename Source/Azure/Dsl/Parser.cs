using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprache;

namespace Azure.Dsl
{
    public class Parser
    {
        public static readonly Parser<Identifier> Identifier = Parse
            .Char(c => char.IsLetter(c) || char.IsDigit(c) || c == '_' || c == '-', "identifier")
            .AtLeastOnce()
            .Text()
            .Select(s => new Identifier(s));
    }

    public class AzureDefinition
    {
        
    }

    public class Identifier
    {
        public Identifier(string s)
        {
            Name = s;
        }

        public string Name { get; }
    }
}
