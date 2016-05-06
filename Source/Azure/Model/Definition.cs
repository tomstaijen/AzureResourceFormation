using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Model
{
    class Definition
    {
        public void Define()
        {
            var nic = new Nic
            {
                Name = "mynic",
            };
        }

    }
}
