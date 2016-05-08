using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Azure.Model;
using Microsoft.Azure;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using NetworkInterface = Microsoft.Azure.Management.Network.Models.NetworkInterface;

namespace Azure
{
    public class MyServiceClientCredentials : ServiceClientCredentials
    {
        public override void InitializeServiceClient<T>(ServiceClient<T> client)
        {
            base.InitializeServiceClient(client);
        }
    }

    public class AzureTest
    {
        public bool test()
        {
            var clientId = "4373f755-1e37-4700-98fb-ea0af15580c9";
            var subscriptionId = "94376942-9b1e-428c-b862-0e5a99734be3";
            var tenant = "d89ecf01-f2a2-4d5a-b059-9e414229a47d"; // AD tentant (see AD endpoints)
            //var token = GetSomeToken(tenant);

            var key = "zlwOyKyV0ip0/rQAmok77+1gC3wA0rToqu7J9Rb87uM=";

            var token = GetAccessToken(tenant, clientId, key);

            var credentials = new TokenCloudCredentials(subscriptionId, token);

            var computeClient = new ComputeManagementClient(credentials);
            var netClient = new NetworkManagementClient(new TokenCredentials(token)) { SubscriptionId = subscriptionId };
            var storageClient = new StorageManagementClient(credentials);

            
            //            var vmResult = client.VirtualMachines.ListAll(new ListParameters());
            //            foreach (var vm in vmResult.VirtualMachines)
            //            {
            //                Console.WriteLine(vm);
            //            }



            //            var interfaces = netClient.NetworkInterfaces.ListAll();
            //            File.WriteAllText("vms.json", JsonConvert.SerializeObject(interfaces));


            var storageAccount = storageClient.StorageAccounts.ListByResourceGroupAsync("lean2").Result.Single();
            var vnet = netClient.VirtualNetworks.ListAll().Single(s => s.Name.Equals("network"));
            var subnet = vnet.Subnets.Single(s => s.Name.Equals("default"));

            var nic = netClient.NetworkInterfaces.CreateOrUpdate("lean2", "mytestnic", new NetworkInterface()
            {
                Location = "West Europe",
                IpConfigurations = new List<NetworkInterfaceIPConfiguration>()
                {
                    new NetworkInterfaceIPConfiguration()
                    {
                        Name = "mytestnicipconf",
                        PrivateIPAllocationMethod = "Dynamic",
                        Subnet = subnet
                    }
                }
            });

            var x = computeClient.VirtualMachines.CreateOrUpdateAsync("lean2", new VirtualMachine
            {
                Location = "West Europe",
                Name = "mytestvm",
                HardwareProfile = new HardwareProfile()
                {
                    VirtualMachineSize = "Standard_D1_V2"
                },
                OSProfile = new OSProfile()
                {
                    AdminUsername = "tom",
                    AdminPassword = "K3nsh1n!",
                    ComputerName = "pietje",
                    LinuxConfiguration = new LinuxConfiguration()
                    {
                        DisablePasswordAuthentication = false
                    }
                },
                NetworkProfile = new NetworkProfile()
                {
                    NetworkInterfaces = new List<NetworkInterfaceReference>()
                    {
                        new NetworkInterfaceReference()
                        {
                            ReferenceUri = nic.Id
                        }
                   }
                },
                StorageProfile = new StorageProfile()
                {
                    ImageReference = new ImageReference()
                    {
                        Publisher = "OpenLogic",
                        Offer = "CentOS",
                        Sku = "7.2",
                        Version = "latest"
                    },
                    OSDisk = new OSDisk()
                    {
                        Name = "osdisk",
                        Caching = "ReadWrite",
                        CreateOption = "fromImage",
                        VirtualHardDisk = new VirtualHardDisk()
                        {
                            Uri = $"{storageAccount.PrimaryEndpoints.Blob.AbsoluteUri}vhds/pietje.vhd"
                        }
                        
                        
                    }
                }
            });

            x.Wait();
        //            File.WriteAllText("vms.json", JsonConvert.SerializeObject(vmResult.VirtualMachines));
            Console.WriteLine(x.Result);

            return true;
        }

        public static string GetAccessToken(string tenant, string appId, string appPass)
        {
            var authenticationContext = new AuthenticationContext($"https://login.windows.net/{tenant}");
            var credential = new ClientCredential(clientId: appId, clientSecret: appPass);
            var result = authenticationContext.AcquireTokenAsync(resource: "https://management.core.windows.net/", clientCredential: credential);

            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }

            string token = result.Result.AccessToken;

            return token;
        }

        public TokenCloudCredentials GetSomeToken(string tenant)
        {
            var context = new AuthenticationContext("https://login.windows.net/" + tenant);
            var result = context.AcquireTokenAsync(
                resource: "https://management.core.windows.net/",
                clientId: "b56e8355-e858-489a-8003-a53b8570f3c8", // id of the application
                redirectUri: new Uri("http://localhost/deployment"),
                parameters: new PlatformParameters(PromptBehavior.Auto, null)
                ).Result;

            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the JWT token");
            }

            string token = result.AccessToken;

            return new TokenCloudCredentials("94376942-9b1e-428c-b862-0e5a99734be3", token); // subscription id
        }




        protected VirtualMachine GetVirtualMachine(string name)
        {
            var result = new VirtualMachine("West Europe");
            return result;
        }

    }

    public class UnusedStuff
    {
        private static X509Certificate2 GetStoreCertificate(string thumbprint)
        {
            List<StoreLocation> locations = new List<StoreLocation>
              {
                StoreLocation.CurrentUser,
                StoreLocation.LocalMachine
              };

            foreach (var location in locations)
            {
                X509Store store = new X509Store("My", location);
                try
                {
                    store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                    X509Certificate2Collection certificates = store.Certificates.Find(
                      X509FindType.FindByThumbprint, thumbprint, false);
                    if (certificates.Count == 1)
                    {
                        return certificates[0];
                    }
                }
                finally
                {
                    store.Close();
                }
            }
            throw new ArgumentException(string.Format(
              "A Certificate with Thumbprint '{0}' could not be located.",
              thumbprint));
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

    }
}
