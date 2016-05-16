namespace Azure.Model.Syntax
{
    public class VNetDefinition : ResourceDefinition
    {
        public string Name { get; set; }
        public string AddressRange { get; set; }

        public Subnet[] Subnets { get; set; }
    }
}