namespace PointOfSaleTerminal.App
{
    public class BasketItem
    {
        public IProduct Product { get; private set; }
        public int Quantity { get; private set; }

        public BasketItem(IProduct product)
        {
            Product = product;
        }
    }
}