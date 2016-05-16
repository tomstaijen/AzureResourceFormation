using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Model.Syntax;

namespace Azure.Dsl
{
    public class FormationBuilder
    {
        public static void New(Action<FormationScope> configurator)
        {
            var scope = new FormationScope();
            configurator(scope);
        }
    }

    public class FormationScope
    {
        public FormationScope()
        {
            Catalog = new Dictionary<string, ResourceDefinition>();
        }

        public IDictionary<string,ResourceDefinition> Catalog { get; set; }

        public ResourceDefinition Add(string name, ResourceDefinition rd)
        {
            Catalog.Add(name, rd);
            return rd;
        }
    }

    public static class ResourceGroepExtensions
    {
        public static ResourceDefinition ResourceGroup(this FormationScope scope, string name)
        {
            return scope.Add(name, new ResourceGroep()
            {
                Name = name
            });
        }
    }
}
