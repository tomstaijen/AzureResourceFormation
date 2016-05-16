namespace Azure.Model.Syntax
{
    public class Subnet : ResourceDefinition
    {
        public string Name { get; set; }
        public string AddressRange { get; set; }

        public ResourceSelector VNet { get; set; }
    }
}