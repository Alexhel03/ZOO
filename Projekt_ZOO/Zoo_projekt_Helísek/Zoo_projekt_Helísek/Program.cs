 using System;
using System.Threading;

namespace Zoo_projekt_Helísek
{
    class Program
    {
        static void Main(string[] args)
        {
            // vytvoří instanci třídy ClassMainMenu
            ClassMainMenu menu  = new ClassMainMenu();
            Console.Title = "ZOO";
            Console.WriteLine("Vítejte!");
            Thread.Sleep(1000);
            menu.ShowMainMenu();
        }
    }
}
