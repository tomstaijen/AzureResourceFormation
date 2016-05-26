using System;
using System.IO;
using AzureResourceFormation.Synchronization;
using AzureResourceFormation.Synchronization.Handlers;
using Newtonsoft.Json;

namespace AzureResourceFormation
{
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                var principal = DefintionReader.ReadPrincipal();
                var scp = new SecretCredentialsProvider();
                scp.SetPrincipal(principal);
                var factory = new AzureVirtualMachineHandler(scp);
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

    public class DefintionReader
    {
        public static AzurePrincipal ReadPrincipal()
        {
            return JsonConvert.DeserializeObject<AzurePrincipal>(File.ReadAllText(@"subscription.json"));
        }
    }
}
