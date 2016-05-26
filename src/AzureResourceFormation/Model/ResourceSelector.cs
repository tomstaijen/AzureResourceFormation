using AzureResourceFormation.Model.Syntax;

namespace AzureResourceFormation.Model
{
    public class ResourceSelector
    {
        private readonly string _name;
        private readonly ResourceDescription _resourceDescription;

        protected ResourceSelector(ResourceDescription resourceDescription)
        {
            _resourceDescription = resourceDescription;
        }

        protected ResourceSelector(string name)
        {
            _name = name;
        }

        public static implicit operator ResourceSelector(ResourceDescription resourceDescription)  // explicit byte to digit conversion operator
        {
            return new ResourceSelector(resourceDescription);
        }

        public static implicit operator ResourceSelector(string name)  // explicit byte to digit conversion operator
        {
            return new ResourceSelector(name);
        }

    }
}
