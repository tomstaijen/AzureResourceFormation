using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Azure.Model;
using Azure.Model.State;

namespace Azure
{
    public interface IResourceHandler<T> where T : Resource
    {
        IEnumerable<T> GetState();

        void Apply(IEnumerable<T> desiredState);
    }
}
