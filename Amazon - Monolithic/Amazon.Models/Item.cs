using System;
using System.Collections.Generic;

namespace Amazon.Repository.Models
{
    public partial class Item
    {
        public Item()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int ItemId { get; set; }
        public string? ItemName { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
