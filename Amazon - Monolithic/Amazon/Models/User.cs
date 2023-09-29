using Amazon.Models;

namespace Amazon
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        // Navigation property for orders
        public List<Order>? Orders { get; set; }
    }

}
