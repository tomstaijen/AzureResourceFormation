using Microsoft.Rest;

namespace AzureResourceFormation.Synchronization
{
    public class SecretCredentialsProvider : ICredentialsProvider
    {
        public SecretCredentialsProvider()
        {
        }

        public void SetPrincipal(AzurePrincipal principal)
        {
            var token = AzureAuthenticator.GetToken(principal);
            TokenCredentials = new TokenCredentials(token);
            SubscriptionId = principal.SubscriptionId;
        }

        public TokenCredentials TokenCredentials { get; private set; }
        public string SubscriptionId { get; private set; }
    }
}