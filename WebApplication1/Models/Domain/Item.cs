namespace WebApplication1.Models.Domain
{
    public class Item
    {

        public Guid itemId { get; set; }
        public string  name { get; set; }
        public int price { get; set; }


        public IEnumerable<orderItem> orderItem { get; set; }


    }
}
