using System.Collections.Generic;
using System.Linq;
using PointOfSaleTerminal.App.Product;

namespace PointOfSaleTerminal.App.Basket
{
    public interface IBasket
    {
        HashSet<IBasketItem> BasketItems { get; }
        decimal BasketTotal { get; }
        void AddToBasket(IProduct product);
        decimal CalculateBasketTotal();
        void PrintBasketContents();
    }

    public class Basket : IBasket
    {
        public HashSet<IBasketItem> BasketItems { get; }
        public decimal BasketTotal { get; private set; }

        public Basket()
        {
            BasketItems = new HashSet<IBasketItem>();
        }

        public void AddToBasket(IProduct product)
        {
            
            var basketItem = BasketItems.SingleOrDefault(x => x.Product.ProductId == product.ProductId);
            if (basketItem == null)
            {
                var newBasketItem = new BasketItem(product);
                BasketItems.Add(newBasketItem);
            }
            else
            {
                basketItem.IncreaseItemQuantity();
            }
        }

        public void PrintBasketContents()
        {
            if (BasketItems.Count == 0)
            {
                UserInterface.UserInterface.DisplayMessage("Basket Empty!\n\n");
            }
            else
            {
                UserInterface.UserInterface.DisplayMessage("BASKET:");
                UserInterface.UserInterface.DisplayMessage($"({"ProductID",5} {"Quantity", 10})");
                foreach (var basketItem in BasketItems)
                {
                    var productId = basketItem.Product.ProductId;
                    var quantity = basketItem.Quantity;
                    UserInterface.UserInterface.DisplayMessage($"{productId,5} {quantity,10}");
                }
                UserInterface.UserInterface.DisplayMessage("\n\n");
            }
        }
        public decimal CalculateBasketTotal()
        {
            foreach (var basketItem in BasketItems)
            {
                var product = basketItem.Product;
                var quantity = basketItem.Quantity;
                var productTotal = product.UnitPrice * quantity;
                var discount = CalculateDiscount(product, quantity);
                var totalPrice = productTotal - discount;
                BasketTotal += totalPrice;
            }

            return BasketTotal;
        }

        private static decimal CalculateDiscount(IProduct product, int quantity)
        {
            if (product.PackSize == 0)
                return 0M;
            
            var numberOfPacks = quantity / product.PackSize;
            var totalDiscount = product.DiscountPerPack * numberOfPacks;
            return totalDiscount;
        }
    }
}
