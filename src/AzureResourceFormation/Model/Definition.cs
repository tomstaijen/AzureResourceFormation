using AzureResourceFormation.Model.Syntax;

namespace AzureResourceFormation.Model
{
    class Definition
    {
        public void Define()
        {
            var nic = new NetworkInterface
            {
                Name = "mynic",
            };
        }

    }
}
