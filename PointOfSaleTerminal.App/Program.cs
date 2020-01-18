using System;
using System.Collections.Generic;
using PointOfSaleTerminal.App.Menus;
using PointOfSaleTerminal.App.Product;

namespace PointOfSaleTerminal.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new HashSet<IProduct>(new ProductEqualityComparer());
            var basket = new Basket.Basket();
            var terminal = new MainMenu(productList, basket);
            terminal.Start();
        }
    }
}
