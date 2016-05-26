using System;
using AzureResourceFormation.Model.Attributes;

namespace AzureResourceFormation.Model
{
    /// <summary>
    ///  Storage Account
    /// </summary>
    public class StorageAccount
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
}