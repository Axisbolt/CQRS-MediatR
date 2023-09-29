using System;
using System.Collections.Generic;

namespace Amazon.Repository.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public int? CourierId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Courier? Courier { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
