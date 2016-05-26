namespace AzureResourceFormation.Synchronization
{
    public class AzurePrincipal
    {
        public string TenantId { get; set; }
        public string SubscriptionId { get; set; }
        public string PrincipalId { get; set; }
        public string PrincipalSecret { get; set; }
    }
}