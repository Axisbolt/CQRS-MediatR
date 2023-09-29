using System;
using System.Collections.Generic;

namespace Amazon.Repository.Models
{
    public partial class OrderItem
    {
        public int OrderId { get; set; }
        public int InventoryId { get; set; }
        public int? Quantity { get; set; }

        public virtual Inventory Inventory { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
