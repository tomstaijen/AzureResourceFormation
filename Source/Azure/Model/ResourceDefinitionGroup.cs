using Azure.Model.Attributes;
using Azure.Model.Syntax;

namespace Azure.Model
{
    /// <summary>
    /// ResourceDefinitionGroup
    /// </summary>
    public class ResourceDefinitionGroup : ResourceDefinition
    {
        [SubscriptionIdentifier]
        public string Name { get; set; }
    }
}