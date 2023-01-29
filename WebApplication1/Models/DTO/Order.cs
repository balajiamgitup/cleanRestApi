using WebApplication1.Models.Domain;

namespace WebApplication1.Models.DTO
{
    public class Order
    {

        public Guid orderId { get; set; }
        public Guid userId { get; set; }
        public int tablenumber { get; set; }
        public Guid statusId { get; set; }


        public orderStatus status { get; set; }

        public IEnumerable<orderItem> orderItem { get; set; }
    }
}
