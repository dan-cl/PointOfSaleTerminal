using System;
using System.Collections.Generic;
using System.Linq;
using PointOfSaleTerminal.App.Menus;

namespace PointOfSaleTerminal.App
{
    public class Terminal
    {
        private readonly HashSet<IProduct> _productList;
        private readonly IBasket _basket;

        public Terminal(HashSet<IProduct> productList, IBasket basket)
        {
            _productList = productList;
            _basket = basket;
        }

        public void Start()
        {
            DisplayMenuOne();
            DisplayMenuTwo();
            DisplayMenuThree();
            DisplayMenuFour();
        }

        private void DisplayMenuOne()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            var exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Welcome to the terminal \n\nOPTIONS \n1: Add product to the system \n9: Exit terminal");
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
                        Console.Clear();
                        break;
                }
            }
        }

        private void DisplayMenuTwo()
        {
            Console.Clear();
            var exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("OPTIONS \n\n1 Add another product \n2 Start scanning items \n9 Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        var addProductMenu = new AddProductMenu(_productList, new ProductFactory());
                        addProductMenu.DisplayMenu();
                        Console.Clear();
                        break;
                    case "2":
                        exitMenu = true;
                        break;
                    case "9":
                        exitMenu = true;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        private void DisplayMenuThree()
        {
            ClearConsoleAndPrintBasket();
            var exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("OPTIONS \n\nEnter the product ID to scan an item OR \n1 Finish scanning \n9 Exit");
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
                    _basket.AddToBasket(product);
                    ClearConsoleAndPrintBasket();
                    Console.WriteLine("Product added to basket\n\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid product code entered\n\n");
                }
            }
        }

        private void DisplayMenuFour()
        {
            ClearConsoleAndPrintBasket();
            var exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("OPTIONS: \n1 Calculate total \n9 Exit");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"BASKET TOTAL: {_basket.CalculateBasketTotal():C}\n\n\n");
                        exitMenu = true;
                        break;
                    case "9":
                        exitMenu = true;
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private void ClearConsoleAndPrintBasket()
        {
            Console.Clear();
            _basket.PrintBasketContents();

        }
    }
}
