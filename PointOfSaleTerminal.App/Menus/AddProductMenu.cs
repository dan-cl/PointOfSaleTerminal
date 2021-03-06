﻿using System.Collections.Generic;
using PointOfSaleTerminal.App.Product;

namespace PointOfSaleTerminal.App.Menus
{
    public class AddProductMenu
    {
        private readonly HashSet<IProduct> _productList;
        private readonly ProductFactory _productFactory;

        public delegate bool InputValidator(string input);

        public AddProductMenu(HashSet<IProduct> productList, ProductFactory productFactory)
        {
            _productList = productList;
            _productFactory = productFactory;
        }

        public void DisplayMenu()
        {
            EnterProductIdMessage();
            EnterUnitPriceMessage();
            EnterPackSizeMessage();
            EnterPackPriceMessage();
            AddProductToSystem();
        }

        private void EnterProductIdMessage()
        {
            const string message = "\nEnter product ID:";
            const string invalidInputMessage = "\nInvalid product ID, Product ID must be a single letter";
            DisplayMessageAndValidateResponse(message, invalidInputMessage, _productFactory.SetProductId);
        }

        private void EnterUnitPriceMessage()
        {
            const string message = "\nEnter unit price:";
            const string invalidInputMessage = "\nInvalid unit price, unit price must be a number";
            DisplayMessageAndValidateResponse(message, invalidInputMessage, _productFactory.SetUnitPrice);
        }

        private void EnterPackSizeMessage()
        {
            const string message = "\nEnter pack size, enter 0 to skip:";
            const string invalidInputMessage = "\nInvalid pack size, pack size must be a whole number";
            DisplayMessageAndValidateResponse(message, invalidInputMessage, _productFactory.SetPackSize);
        }

        private void EnterPackPriceMessage()
        {
            const string message = "\nEnter pack price, enter 0 to skip:";
            const string invalidInputMessage = "\nInvalid pack price, pack price must be a number";
            DisplayMessageAndValidateResponse(message, invalidInputMessage, _productFactory.SetPackPrice);
        }

        private void AddProductToSystem()
        {
            _productFactory.AddProductToSystem(_productList);
        }

        private static void DisplayMessageAndValidateResponse(string message, string invalidInputMessage, InputValidator inputValidator)
        {
            bool finished = false;
           UserInterface.UserInterface.ClearScreen();
            while (!finished)
            {
                UserInterface.UserInterface.DisplayMessage(message);
                finished = inputValidator(UserInterface.UserInterface.GetInput());
                if (finished) continue;

                UserInterface.UserInterface.ClearScreen();
                UserInterface.UserInterface.DisplayMessage(invalidInputMessage);
            }
        }
    }
}