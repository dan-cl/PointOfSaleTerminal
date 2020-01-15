namespace PointOfSaleTerminal.App
{
    public class BasketItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public BasketItem(Product product)
        {
            Product = product;
        }
    }
}