using System;

namespace PointOfSaleTerminal.App.Menus
{
    public class StartMenu : IMenu
    {
        private readonly IMenu _addProductMenu;
        
        public StartMenu(IMenu addProductMenu)
        {
            _addProductMenu = addProductMenu;
        }

        public void DisplayMenu()
        {
            var exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("Welcome to the terminal, press 1 to add products to the system  or 9 to exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        _addProductMenu.DisplayMenu();
                        exitMenu = true;
                        break;
                    case "9":
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input\n");
                        break;
                }
            }
        }
    }
}
