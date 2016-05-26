using AzureResourceFormation.Model.Attributes;
using Microsoft.Azure.Management.Compute.Models;

namespace AzureResourceFormation.Model.Syntax
{
    /// <summary>
    /// Virtual Machine
    /// </summary>
    public class Vm : ResourceDescription
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


