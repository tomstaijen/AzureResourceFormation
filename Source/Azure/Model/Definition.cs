﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Model.Syntax;

namespace Azure.Model
{
    class Definition
    {
        public void Define()
        {
            var nic = new NetworkInterface
            {
                Name = "mynic",
            };
        }

    }
}
