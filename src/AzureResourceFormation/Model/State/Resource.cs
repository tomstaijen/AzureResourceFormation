using AzureResourceFormation.Model.Syntax;

namespace AzureResourceFormation.Model.State
{
    public class Resource
    {
        public string LocalName { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public Location Location { get; set; }
    }
}
