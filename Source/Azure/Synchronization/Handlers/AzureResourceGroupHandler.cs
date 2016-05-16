using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Model.State;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest;

namespace Azure.Synchronization.Handlers
{
    class AzureResourceGroupHandler : IResourceHandler<ResourceGroup>
    {
        private readonly ICredentialsProvider _credentialsProvider;
        public AzureResourceGroupHandler(ICredentialsProvider credentialsProvider)
        {
            _credentialsProvider = credentialsProvider;
        }

        public IEnumerable<ResourceGroup> GetState()
        {
            // new ResourceManagementClient(new TokenCredentials(_credentialsProvider.TokenCloudCredentials.Token)).
            return null;
        }

        public void Apply(IEnumerable<ResourceGroup> desiredState)
        {
            throw new NotImplementedException();
        }
    }
}
