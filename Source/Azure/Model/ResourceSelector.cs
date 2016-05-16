using Azure.Model.Syntax;

namespace Azure.Model
{
    public class ResourceSelector
    {
        private readonly string _name;
        private readonly ResourceDefinition _resourceDefinition;

        protected ResourceSelector(ResourceDefinition resourceDefinition)
        {
            _resourceDefinition = resourceDefinition;
        }

        protected ResourceSelector(string name)
        {
            _name = name;
        }

        public static implicit operator ResourceSelector(ResourceDefinition resourceDefinition)  // explicit byte to digit conversion operator
        {
            return new ResourceSelector(resourceDefinition);
        }

        public static implicit operator ResourceSelector(string name)  // explicit byte to digit conversion operator
        {
            return new ResourceSelector(name);
        }

    }
}
