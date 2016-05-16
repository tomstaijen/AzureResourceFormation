using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Model.Syntax;

namespace Azure.Model.State
{
    public class Resource
    {
        public string LocalName { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public Location Location { get; set; }
    }
}
