﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSNET6Demo.Events
{
    public class Constants
    {
        public const string QUEUE_CUSTOMER_CREATED = "customer_created";
        public const string QUEUE_CUSTOMER_UPDATED = "customer_updated";
        public const string QUEUE_CUSTOMER_DELETED = "customer_deleted";
    }
}
