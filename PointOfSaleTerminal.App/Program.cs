using System;
using System.Collections.Generic;
using PointOfSaleTerminal.App.Menus;

namespace PointOfSaleTerminal.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new HashSet<IProduct>(new ProductEqualityComparer());
            var basket = new Basket();
            var terminal = new Terminal(productList, basket);
            terminal.Start();
        }
    }
}
