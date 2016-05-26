using System.Collections.Generic;
using AzureResourceFormation.Model.State;

namespace AzureResourceFormation.Synchronization
{
    public interface IResourceHandler<T> where T : Resource
    {
        IEnumerable<T> GetState();

        void Apply(IEnumerable<T> desiredState);
    }
}
