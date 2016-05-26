using System.Collections.Generic;
using System.Linq;
using AzureResourceFormation.Model.State;
using Microsoft.Azure.Management.ResourceManager;

namespace AzureResourceFormation.Synchronization.Handlers
{
    class AzureResourceGroupHandler : IResourceHandler<ResourceGroupState>
    {
        private readonly ICredentialsProvider _credentialsProvider;
        public AzureResourceGroupHandler(ICredentialsProvider credentialsProvider)
        {
            _credentialsProvider = credentialsProvider;
        }

        public IEnumerable<ResourceGroupState> GetState()
        {
            return GetClient()
                .ResourceGroups.List().Select(rg => new ResourceGroupState
                {
                    Name = rg.Name,
                    Id = rg.Id
                });
        }

        public ResourceManagementClient GetClient()
        {
            return new ResourceManagementClient(_credentialsProvider.TokenCredentials)
            {
                SubscriptionId = _credentialsProvider.SubscriptionId
            };
        }

        public void Apply(IEnumerable<ResourceGroupState> desiredState)
        {
            
        }
    }
}
