using AzureResourceFormation.Model.Attributes;
using AzureResourceFormation.Model.Syntax;

namespace AzureResourceFormation.Model
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