using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Model;
using Azure.Model.Syntax;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Azure
{
    public interface IResourceHandler<T>
    {
        IEnumerable<T> GetState();

        void Apply(IEnumerable<T> desiredState);
    }

    class AzureVmHandler : IResourceHandler<Vm>
    {
        private readonly ICredentialsProvider _credentialsProvider;

        public AzureVmHandler(ICredentialsProvider credentialsProvider)
        {
            _credentialsProvider = credentialsProvider;
        }

        public IEnumerable<Vm> GetState()
        {
            return GetClient().VirtualMachines.ListAll(new ListParameters()).VirtualMachines.Select(v => 
            new Vm
            {
                Id = v.Id,
                Name = v.Name,
                Location = (Location) v.Location,
                Size = v.HardwareProfile.VirtualMachineSize,
            });
        }

        public void Apply(IEnumerable<Vm> desiredState)
        {
            throw new NotImplementedException();
        }

        private ComputeManagementClient GetClient()
        {
            return new ComputeManagementClient(_credentialsProvider.TokenCloudCredentials);
        }
    }
}
