namespace Azure.Model.Syntax
{
    public class VNetDescription : ResourceDescription
    {
        public string Name { get; set; }
        public string AddressRange { get; set; }

        public Subnet[] Subnets { get; set; }
    }
}