using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Model.State;
using Azure.Model.Syntax;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Azure
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
            return GetClient().VirtualMachines.ListAll(new ListParameters()).VirtualMachines.Select(v => 
                new VirtualMachineState
                {
                    Id = v.Id,
                    Name = v.Name,
                    Location = (Location) v.Location,
                    Size = v.HardwareProfile.VirtualMachineSize,
                });
        }

        public void Apply(IEnumerable<VirtualMachineState> desiredState)
        {
            throw new NotImplementedException();
        }

        private ComputeManagementClient GetClient()
        {
            return new ComputeManagementClient(_credentialsProvider.TokenCloudCredentials);
        }
    }
}