namespace CoreProject.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Car car { get; set; }
        public uint price { get; set; }

        public string shopCartId { get; set; }
    }
}
