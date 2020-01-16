using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSaleTerminal.App
{
    public class OptionsMenu
    {
        public List<Product> ProductList { get; private set; }
        
        public OptionsMenu(List<Product> productList)
        {
            ProductList = productList;
        }

        public void StartMenu()
        {
            Console.WriteLine("Welcome to the terminal, press 1 to add products to the system  or 9 to exit");
            switch (Console.ReadLine())
            {
                case "1":
                    AddProductMenu();
                    return;
                case "9":
                    System.Environment.Exit(0);
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    StartMenu();
                    return;
            }
        }

        private void AddProductMenu()
        {
           Console.WriteLine("Enter product ID:");
           var productId = Console.ReadLine();
           Console.WriteLine("Enter unit price:");
           var unitPrice = double.Parse(Console.ReadLine());
           Console.WriteLine("Enter pack size or leave empty of there is no pack size:");
           if (Console.ReadLine().Length == 0)
           {
               var product = new Product(productId, unitPrice);
               ProductList.Add(product);
           }
           else
           {
               Console.WriteLine("Enter pack size:");
               var packSize = int.Parse(Console.ReadLine());
               Console.WriteLine("Enter pack price:");
               var packPrice = double.Parse(Console.ReadLine());
               var product = new Product(productId, unitPrice, packSize, packPrice);
               ProductList.Add(product);
           }
        }
    }
}
