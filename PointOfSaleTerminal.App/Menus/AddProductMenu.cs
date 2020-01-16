using System;
using System.Collections.Generic;

namespace PointOfSaleTerminal.App.Menus
{
    public class AddProductMenu : IMenu
    {
        private IList<IProduct> _productList;
        private readonly ProductFactory _productFactory;

        public delegate bool InputValidator(string input);

        public AddProductMenu(IList<IProduct> productList, ProductFactory productFactory)
        {
            _productList = productList;
            _productFactory = productFactory;
        }

        public void DisplayMenu()
        {
            EnterProductIdMessage();
            EnterUnitPriceMessage();
        }

        private void EnterProductIdMessage()
        {
            const string message = "Enter product ID:";
            const string invalidInputMessage = "Invalid product ID, Product ID must be 1 character";
            DisplayMessageAndValidateResponse(message, invalidInputMessage, _productFactory.ValidProductId);
        }

        private void EnterUnitPriceMessage()
        {
            const string message = "Enter unit price:";
            const string invalidInputMessage = "Invalid unit price, unit price must be a number ";
            DisplayMessageAndValidateResponse(message, invalidInputMessage, _productFactory.ValidUnitPrice);

        }

        public void DisplayMessageAndValidateResponse(string message, string invalidInputMessage, InputValidator inputValidator)
        {
            bool finished = false;
            
            while (!finished)
            {
                Console.WriteLine(message);
                finished = inputValidator(Console.ReadLine());
                  if(!finished)
                    Console.WriteLine(invalidInputMessage);
            }
        }
    }
}