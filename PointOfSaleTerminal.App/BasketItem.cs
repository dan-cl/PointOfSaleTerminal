namespace PointOfSaleTerminal.App
{
    public interface IBasketItem
    {
        IProduct Product { get; set; }
        int Quantity { get; set;  }
        void IncreaseItemQuantity();
    }

    public class BasketItem : IBasketItem
    {
        public IProduct Product { get; set; }
        public int Quantity { get; set; }

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