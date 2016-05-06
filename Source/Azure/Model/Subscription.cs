﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Model
{
    class Subscription
    {
        public string TenantId { get; set; }

        public string SubscriptionId { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }
    }
}
