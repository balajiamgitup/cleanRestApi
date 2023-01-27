namespace WebApplication1.Models.Domain
{
    public class orderItem
    {

        public Guid orderItemId { get; set; }
        public Guid orderId { get; set; }
        public Guid itemId { get; set; }
        public int quantity { get; set; }

        public Item item { get; set; }
        public order order { get; set; }

        public IEnumerable<bill> bill { get; set; }

    }
}
