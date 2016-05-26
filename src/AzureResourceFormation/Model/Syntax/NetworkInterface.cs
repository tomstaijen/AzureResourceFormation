using AzureResourceFormation.Model.Attributes;

namespace AzureResourceFormation.Model.Syntax
{
    public class NetworkInterface : ResourceDescription
    {
        /// <summary>
        /// Name is unique per resourcegroup
        /// </summary>
        [ResourceGroupIdentifier]
        public string Name { get; set; }

        
        public ResourceSelector Subnet { get; set; }
    }
}