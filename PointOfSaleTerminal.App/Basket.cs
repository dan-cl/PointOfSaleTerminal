using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace PointOfSaleTerminal.App
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

        public void PrintBasketContents()
        {
            foreach (var basketItem in BasketItems)
            {
                Console.WriteLine(basketItem.Product.ProductId);
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

        //private decimal CalculateDiscount(IBasketItem basketItem)
        //{
        //    var product = basketItem.Product;
        //    var packSize = product.PackSize;
        //    var discountPerPack = product.PackPrice * product.UnitPrice - product.PackPrice;
        //    int numberOfPacks = basketItem.Quantity / packSize;
        //    if (numberOfPacks >= 1)
        //        return numberOfPacks * discountPerPack;

        //    return 0;
        //}
    }
}
