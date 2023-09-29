namespace Amazon.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int CourierId { get; set; }
        public DateTime OrderDate { get; set; }

    }

    public class UserWithOrdersResult
    {
        public string UserName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
