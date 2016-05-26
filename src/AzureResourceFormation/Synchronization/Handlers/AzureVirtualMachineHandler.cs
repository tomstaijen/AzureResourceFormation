using System;
using System.Collections.Generic;
using System.Linq;
using AzureResourceFormation.Model.State;
using AzureResourceFormation.Model.Syntax;
using Microsoft.Azure.Management.Compute;

namespace AzureResourceFormation.Synchronization.Handlers
{
    class AzureVirtualMachineHandler : IResourceHandler<VirtualMachineState>
    {
        private readonly ICredentialsProvider _credentialsProvider;

        public AzureVirtualMachineHandler(ICredentialsProvider credentialsProvider)
        {
            _credentialsProvider = credentialsProvider;
        }

        public IEnumerable<VirtualMachineState> GetState()
        {
            return GetClient().VirtualMachines.ListAll().Select(v => 
                new VirtualMachineState
                {
                    Id = v.Id,
                    Name = v.Name,
                    Location = (Location) v.Location,
                    Size = v.HardwareProfile.VmSize,
                });
        }

        public void Apply(IEnumerable<VirtualMachineState> desiredState)
        {
            throw new NotImplementedException();
        }

        private ComputeManagementClient GetClient()
        {
            return new ComputeManagementClient(_credentialsProvider.TokenCredentials)
            {
                SubscriptionId = _credentialsProvider.SubscriptionId
            };
        }
    }
}