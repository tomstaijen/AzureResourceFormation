namespace Azure.Model
{
    /// <summary>
    /// ResourceGroup
    /// </summary>
    class ResourceGroup : Resource
    {
        [SubscriptionIdentifier]
        public string Name { get; set; }
    }
}