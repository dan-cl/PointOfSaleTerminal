namespace PointOfSaleTerminal.App
{
    public class BasketItem 
    {
        public IProduct Product { get; }
        public int Quantity { get; private set; }

        public BasketItem(IProduct product)
        {
            Product = product;
            Quantity = 1;
        }

        public void IncreaseItemQuantity()
        {
            Quantity++;
        }
    }
}