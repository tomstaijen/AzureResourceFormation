using Azure.Model.Attributes;
using Azure.Model.Syntax;

namespace Azure.Model
{
    /// <summary>
    /// ResourceDescriptionGroup
    /// </summary>
    public class ResourceDescriptionGroup : ResourceDescription
    {
        [SubscriptionIdentifier]
        public string Name { get; set; }
    }
}