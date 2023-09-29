using System;
using System.Collections.Generic;

namespace Amazon.Repository.Models
{
    public partial class Courier
    {
        public Courier()
        {
            Orders = new HashSet<Order>();
        }

        public int CourierId { get; set; }
        public string? CourierName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
