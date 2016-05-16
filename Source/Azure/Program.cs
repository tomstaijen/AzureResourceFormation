using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.Azure.Management.Compute;
using Newtonsoft.Json;

namespace Azure
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                var principal = new AzurePrincipal()
                {
                    PrincipalId = "4373f755-1e37-4700-98fb-ea0af15580c9",
                    SubscriptionId = "94376942-9b1e-428c-b862-0e5a99734be3",
                    TenantId = "d89ecf01-f2a2-4d5a-b059-9e414229a47d",
                    PrincipalSecret = "zlwOyKyV0ip0/rQAmok77+1gC3wA0rToqu7J9Rb87uM="
                };
                var scp = new SecretCredentialsProvider();
                scp.SetPrincipal(principal);
                var factory = new AzureVmHandler(scp);
                var state = factory.GetState();
                foreach (var s in state)
                {
                    Console.WriteLine(JsonConvert.ToString(s));
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return 1;
            }
        }
    }
}
