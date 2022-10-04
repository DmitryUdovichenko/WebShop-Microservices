using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class BasketCheckoutEvent : BaseEvent
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }

        public int AddressId { get; set; }
        public int Payment { get; set; }
    }
}
