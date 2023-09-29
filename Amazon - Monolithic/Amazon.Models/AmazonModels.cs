using System.ComponentModel.DataAnnotations;

namespace Amazon.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }

        // Add a list of items for this user
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }

}