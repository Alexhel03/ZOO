using System;
using System.Collections.Generic;
using System.Text;
using System.Threading; // Přidává příkaz Thread.Sleep, který slouží k

namespace Zoo_projekt_Helísek
{
    class ClassMainMenu
    {
        public void ShowMainMenu()
        {
            // Vyčistí konzoli
            Console.Clear();

            // Vytvoří nové instance tříd ClassAccountMenu, Funkce1 a ClassSettingMenu
            ClassAccountMenu accounts = new ClassAccountMenu();
            Funkce1 gc = new Funkce1();
            ClassSettingMenu setting = new ClassSettingMenu();

            // Vypíše hlavní menu do konzole
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Hrát");
            Console.WriteLine("2. Nastavení");
            Console.WriteLine("3. Konec");

            // Získá volbu uživatele, umožňuje výběr mezi 1 a 3
            int choice = gc.GetChoice(3);

            // Pokud uživatel zvolí 1, zobrazí menu účtů
            switch (choice)
            {
                case 1:
                    accounts.ShowAccountMenu();
                    break;
                case 2:
                    setting.ShowSettingsMenu();
                    break;
                case 3:
                    Console.WriteLine("Ukončuji...");

                    // Pozastaví činnost o 2s
                    Thread.Sleep(2000);

                    // Ukončí program
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }
    }
}
