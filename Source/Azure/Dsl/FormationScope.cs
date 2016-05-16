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
            Catalog = new Dictionary<string, ResourceDescription>();
        }

        public IDictionary<string,ResourceDescription> Catalog { get; set; }

        public ResourceDescription Add(string name, ResourceDescription rd)
        {
            Catalog.Add(name, rd);
            return rd;
        }
    }

    public static class ResourceGroepExtensions
    {
        public static ResourceDescription ResourceGroup(this FormationScope scope, string name)
        {
            return scope.Add(name, new ResourceGroep()
            {
                Name = name
            });
        }
    }
}
