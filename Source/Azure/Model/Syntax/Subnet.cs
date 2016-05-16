namespace Azure.Model.Syntax
{
    public class Subnet : ResourceDescription
    {
        public string Name { get; set; }
        public string AddressRange { get; set; }

        public ResourceSelector VNet { get; set; }
    }
}