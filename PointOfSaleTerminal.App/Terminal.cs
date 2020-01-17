using System;
using System.Collections.Generic;
using System.Linq;
using PointOfSaleTerminal.App.Menus;

namespace PointOfSaleTerminal.App
{
    public class Terminal
    {
        private readonly HashSet<IProduct> _productList;

        public Terminal(HashSet<IProduct> productList)
        {
            _productList = productList;
        }

        public void Start()
        {
            DisplayMenuOne();
            DisplayMenuTwo();
            DisplayMenuThree();
        }

        private void DisplayMenuOne()
        {
            var exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Welcome to the terminal, press 1 to add product to the system or 9 to exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        var addProductMenu = new AddProductMenu(_productList, new ProductFactory());
                        addProductMenu.DisplayMenu();
                        exitMenu = true;
                        break;
                    case "9":
                        exitMenu = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input\n");
                        break;
                }
            }
        }

        private void DisplayMenuThree()
        {
            var exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Enter the product ID to scan an item, enter 1 to finish scanning or 9 to exit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        exitMenu = true;
                        break;
                    case "9":
                        exitMenu = true;
                        Environment.Exit(0);
                        break;
                }

                if (exitMenu) continue;

                var product = _productList.SingleOrDefault(x => x.ProductId == input?.ToUpper());
                if (product != null)
                {
                    //Add product to basket
                    Console.WriteLine("Product added to basket");
                }
                else
                {
                    Console.WriteLine("Invalid product code entered");
                }
            }
        }

        private void DisplayMenuTwo()
        {
            var exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Press 1 to add another product, 2 to start scanning items or 9 to exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        var addProductMenu = new AddProductMenu(_productList, new ProductFactory());
                        addProductMenu.DisplayMenu();
                        break;
                    case "2":
                        exitMenu = true;
                        break;
                    case "9":
                        exitMenu = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input\n");
                        break;
                }
            }
        }
    }
}
