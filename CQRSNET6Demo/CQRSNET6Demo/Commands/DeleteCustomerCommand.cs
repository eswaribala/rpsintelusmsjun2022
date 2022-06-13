using CQRSNET6Demo.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSNET6Demo.Commands
{
    public class DeleteCustomerCommand : Command
    {
        internal CustomerDeletedEvent ToCustomerEvent()
        {
            return new CustomerDeletedEvent
            {
                CustomerId = this.Id
            };
        }
    }
}
