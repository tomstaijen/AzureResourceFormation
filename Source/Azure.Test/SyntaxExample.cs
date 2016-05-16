using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Dsl;
using Azure.Model;
using Azure.Model.Syntax;

namespace Azure.Test
{
    public class SyntaxExample
    {
        public void Sample()
        {
            ResourceDefinition.DefaultLocation = "westeurope";
            FormationBuilder.New(fs =>
            {
                var rg = fs.ResourceGroup("env");
            });

            var vnet = new VNetDefinition
            {
                Name = "vnet",
                AddressRange = "192.168.0.0/16",
                Subnets = new []
                {
                    new Subnet()
                    {
                        Name = "subnet2",
                        AddressRange = "192.168.1.0/24"
                    }
                }
            };

            var sn = new Subnet()
            {
                Name = "subnet1",
                AddressRange = "192.168.1.0/24",
                VNet = "vnet"
            };

            var nic1 = new NetworkInterface
            {
                Name = "nic",
                Subnet = "vnet.subnet2"
            };

            var saStandard = new StorageAccount
            {
                Name = "sastandard",
                Sku = StorageAccount.StorageSku.Standard
            };

            var saPremium = new StorageAccount()
            {
                Name = "saPremium",
                Sku = StorageAccount.StorageSku.Premium
            };

            var module = Module.Build(mc =>
            {
                var nic2 = new NetworkInterface
                {
                    Name = $"nic{mc.Name}{mc.Index}",
                    Subnet = sn
                };

                var vm = new Vm()
                {
                    Name = "vm",
                    Size = "Standard_D1_V2",
                    Network = new[] { nic1, nic2 },
                };
            });

            var rabbits = module.Instance("rabbitmq", 4);
        }
    }
}
