using Azure.Model.Attributes;

namespace Azure.Model.Syntax
{
    public class NetworkInterface : ResourceDefinition
    {
        /// <summary>
        /// Name is unique per resourcegroup
        /// </summary>
        [ResourceGroupIdentifier]
        public string Name { get; set; }

        
        public ResourceSelector Subnet { get; set; }
    }
}