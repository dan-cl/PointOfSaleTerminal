using System;
using System.Collections.Generic;
using System.Linq;
using PointOfSaleTerminal.App.Basket;
using PointOfSaleTerminal.App.Product;

namespace PointOfSaleTerminal.App.Menus
{
    public class MainMenu
    {
        private readonly HashSet<IProduct> _productList;
        private readonly IBasket _basket;

        public MainMenu(HashSet<IProduct> productList, IBasket basket)
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
            Console.ForegroundColor = ConsoleColor.Green;
            UserInterface.UserInterface.ClearScreen();
            var exitMenu = false;
            while (!exitMenu)
            {
                UserInterface.UserInterface.DisplayMessage("Welcome to the terminal \n\nOPTIONS \n1: Add product to the system \n9: Exit terminal");
                switch (UserInterface.UserInterface.GetInput())
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
                       UserInterface.UserInterface.ClearScreen();
                        break;
                }
            }
        }

        private void DisplayMenuTwo()
        {
           UserInterface.UserInterface.ClearScreen();
            var exitMenu = false;
            while (!exitMenu)
            {
                UserInterface.UserInterface.DisplayMessage("OPTIONS \n\n1: Add another product \n2: Start scanning items \n9: Exit");
                var input = UserInterface.UserInterface.GetInput();
                switch (input)
                {
                    case "1":
                        var addProductMenu = new AddProductMenu(_productList, new ProductFactory());
                        addProductMenu.DisplayMenu();
                        UserInterface.UserInterface.ClearScreen();
                        break;
                    case "2":
                        exitMenu = true;
                        break;
                    case "9":
                        exitMenu = true;
                        Environment.Exit(0);
                        break;
                    default:
                       UserInterface.UserInterface.ClearScreen();
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
                UserInterface.UserInterface.DisplayMessage("OPTIONS \n\nEnter the product ID to scan an item OR \n1: Finish scanning \n9: Exit");
                var input = UserInterface.UserInterface.GetInput();
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
                    UserInterface.UserInterface.DisplayMessage("Product added to basket\n\n");
                }
                else
                {
                    ClearConsoleAndPrintBasket();
                    UserInterface.UserInterface.DisplayMessage("Invalid product code entered\n\n");
                }
            }
        }

        private void DisplayMenuFour()
        {
            var exitMenu = false;
            while (!exitMenu)
            {
                ClearConsoleAndPrintBasket();
                UserInterface.UserInterface.DisplayMessage("OPTIONS: \n1: Calculate total \n9: Exit");
                var input = UserInterface.UserInterface.GetInput();
                switch (input)
                {
                    case "1":
                       UserInterface.UserInterface.ClearScreen();
                        UserInterface.UserInterface.DisplayMessage($"BASKET TOTAL: {_basket.CalculateBasketTotal():C}\n\n\n");
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
           UserInterface.UserInterface.ClearScreen();
            _basket.PrintBasketContents();
        }
    }
}
