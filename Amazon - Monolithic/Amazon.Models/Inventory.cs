using System;
using System.Collections.Generic;

namespace Amazon.Repository.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int InventoryId { get; set; }
        public int? ItemId { get; set; }
        public int? StockQuantity { get; set; }

        public virtual Item? Item { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
