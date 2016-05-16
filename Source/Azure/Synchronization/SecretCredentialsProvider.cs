using Microsoft.Azure;

namespace Azure
{
    public class SecretCredentialsProvider : ICredentialsProvider
    {
        public SecretCredentialsProvider()
        {
        }

        public void SetPrincipal(AzurePrincipal principal)
        {
            var token = AzureAuthenticator.GetToken(principal);
            TokenCloudCredentials = new TokenCloudCredentials(principal.SubscriptionId, token);
        }

        public TokenCloudCredentials TokenCloudCredentials { get; private set; }
    }
}