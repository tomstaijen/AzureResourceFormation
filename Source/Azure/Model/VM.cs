using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Models;

namespace Azure.Model
{
    class Location
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// Resources are referencable. Provisionstate will be taken care of, required id will be computed.
    /// </summary>
    class Resource {

        public Resource()
        {
            Location = DefaultLocation;
        }

        public static Location DefaultLocation { get; set; }

        public Location Location { get; set; }
    }

    class Nic : Resource
    {
        /// <summary>
        /// Name is unique per resourcegroup
        /// </summary>
        [ResourceGroupIdentifier]
        public string Name { get; set; }
    }

    class VNet : Resource
    {
    }

    class Subnet : Resource
    {
    }


    /// <summary>
    /// Virtual Machine
    /// </summary>
    class Vm : Resource
    {
        public Vm()
        {
            OsProfile = new OSProfile();
        }

        [ResourceGroupIdentifier]
        public string Name { get; set; }

        /// <summary>
        /// e.g.Standard_D1_v2
        /// </summary>
        public string Size { get; set; }

        public Nic[] Network { get; set; }

        public OSProfile OsProfile { get; private set; }
    }

    /// <summary>
    /// ResourceGroup
    /// </summary>
    class Rg : Resource
    {
        [SubscriptionIdentifier]
        public string Name { get; set; }
    }

    public class RequiredAttribute : Attribute
    {

    }

    public class State : Attribute
    {
        
    }

    public class ResourceGroupIdentifier : RequiredAttribute {
    }

    public class SubscriptionIdentifier : RequiredAttribute {
            
    }

    public class GlobalIdentifier : Attribute
    {
        
    }

    /// <summary>
    ///  Storage Account
    /// </summary>
    public class Sa
    {
        [GlobalIdentifier]
        public String Name { get; set; }
        public StorageSku Sku { get; set; }

        public enum StorageSku
        {
            Standard,
            Premium
        }

       
    }

    public class Disk
    {
        public Sa Account { get; set; }
    }
}


