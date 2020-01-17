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
            var startMenu = new StartMenu(new AddProductMenu(productList, new ProductFactory()));
            startMenu.DisplayMenu();
        }
    }
}
