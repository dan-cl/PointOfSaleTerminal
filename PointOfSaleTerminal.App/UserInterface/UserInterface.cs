using System;

namespace PointOfSaleTerminal.App.UserInterface
{
    internal static class UserInterface
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetInput()
        {
            return Console.ReadLine();
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }
    }
}
