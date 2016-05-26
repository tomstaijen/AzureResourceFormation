using Microsoft.Rest;

namespace AzureResourceFormation.Synchronization
{
    public interface ICredentialsProvider
    {
        TokenCredentials TokenCredentials { get; }

        string SubscriptionId { get; }
    }
}