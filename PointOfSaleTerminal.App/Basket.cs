using System.Collections.Generic;
using System.Linq;

namespace PointOfSaleTerminal.App
{
    public interface IBasket
    {
        HashSet<BasketItem> BasketItems { get; }
        double BasketTotal { get; }
        void AddToBasket(IProduct product);
    }

    public class Basket : IBasket
    {
        public HashSet<BasketItem> BasketItems { get; }
        public double BasketTotal { get; private set; }

        public Basket()
        {
            BasketItems = new HashSet<BasketItem>();
        }

        public void AddToBasket(IProduct product)
        {
            
            var basketItem = BasketItems.SingleOrDefault(x => x.Product.ProductId == product.ProductId);
            if (basketItem != null)
            {
                basketItem.IncreaseItemQuantity();
            }
            else
            {
                var newBasketItem = new BasketItem(product);
                BasketItems.Add(newBasketItem);
            }
        }
    }
}
