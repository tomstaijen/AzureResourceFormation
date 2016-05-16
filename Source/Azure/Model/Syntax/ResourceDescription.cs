namespace Azure.Model.Syntax
{
    /// <summary>
    /// Resources are referencable. Provisionstate will be taken care of, required id will be computed.
    /// </summary>
    public class ResourceDescription {

        public ResourceDescription()
        {
            Location = DefaultLocation;
        }

        public static Location DefaultLocation { get; set; }

        public Location Location { get; set; }
    }
}