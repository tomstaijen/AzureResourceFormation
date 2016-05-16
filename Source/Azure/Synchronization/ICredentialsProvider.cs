using Microsoft.Azure;

namespace Azure
{
    public interface ICredentialsProvider
    {
        TokenCloudCredentials TokenCloudCredentials { get; }
    }
}