namespace Amazon.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int CourierId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
