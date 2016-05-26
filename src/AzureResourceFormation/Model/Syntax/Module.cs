using System;

namespace AzureResourceFormation.Model.Syntax
{
    public class ResourceTemplate
    {
        
    }

    public class Module : ResourceTemplate
    {
        public static Module Build(Action<ModuleContext> builder)
        {
            return new Module();
        }

        public ModuleInstance Instance(string name, int count, Action<ModuleContext> contextConfigurator = null)
        {
            return new ModuleInstance();
        }
    }

    /// <summary>
    /// Virtual context to support lookup of inner resources
    /// </summary>
    public class ModuleInstance : ResourceDescription
    {
        public string Name { get; set; }
    }

    public class ModuleContext
    {
        public int Index { get; set; }
        public string Name { get; set; }
    }
}
