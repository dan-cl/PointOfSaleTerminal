using System;
using System.Collections.Generic;

namespace PointOfSaleTerminal.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsMenu = new OptionsMenu(new List<Product>());
            optionsMenu.StartMenu();
        }
    }
}
