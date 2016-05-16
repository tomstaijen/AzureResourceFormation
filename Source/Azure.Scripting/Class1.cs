using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace Azure.Scripting
{
    public class Class1
    {
        public async Task<int> Add(string whatToAdd)
        {
            A = 4;
            string code = $"A + {whatToAdd}";

            var options = ScriptOptions.Default;

            var result = await CSharpScript.EvaluateAsync<int>(code, null, this);
            return result;
        }

        public int A { get; set; }

        public int One()
        {
            return 1;
        }
    }

    public static class Class1Extensions
    {
        public static int Zero(this Class1 c)
        {
            return 1;
        }
    }
}
