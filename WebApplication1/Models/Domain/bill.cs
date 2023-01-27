namespace WebApplication1.Models.Domain
{
    public class bill
    {


        public Guid billId { get; set; }
        public Guid orderItemId { get; set; }
        public int totalBill { get; set; }


        public orderItem orderItem { get; set; }
    }
}
