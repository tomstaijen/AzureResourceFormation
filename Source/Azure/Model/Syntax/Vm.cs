using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Model.Attributes;
using Microsoft.Azure.Management.Compute.Models;

namespace Azure.Model.Syntax
{
    /// <summary>
    /// Virtual Machine
    /// </summary>
    public class Vm : ResourceDefinition
    {
        public string Id { get; set; }

        public Vm()
        {
            OsProfile = new OSProfile();
        }

        [ResourceGroupIdentifier]
        public string Name { get; set; }

        /// <summary>
        /// e.g.Standard_D1_v2
        /// </summary>
        public string Size { get; set; }

        public NetworkInterface[] Network { get; set; }

        public OSProfile OsProfile { get; private set; }
    }
}


