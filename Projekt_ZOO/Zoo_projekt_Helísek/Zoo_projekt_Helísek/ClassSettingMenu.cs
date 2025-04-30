using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Zoo_projekt_Helísek
{
    class ClassSettingMenu
    {
        ClassMainMenu mainMenu = new ClassMainMenu();
        Funkce1 gc = new Funkce1();

        // Metoda pro zobrazení menu nastavení.
        public void ShowSettingsMenu()
        {
            Console.Clear();
            Console.WriteLine("Nastavení:");
            Console.WriteLine("1. Barva písma");
            Console.WriteLine("2. Barva pozadí");
            Console.WriteLine("3. Zpět");

            int choice = gc.GetChoice(3);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Vybral jsi barvu písma...");
                    ShowColorsForeground();
                    break;
                case 2:
                    Console.WriteLine("Vybral jsi barvu pozadí...");
                    ShowColorsBackground();
                    break;
                case 3:
                    mainMenu.ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }

        }
        private void ShowColorsForeground()
        {
            Console.Clear();
            Console.WriteLine("Vyber si barvu písma:");
            Console.WriteLine("------------------------");

            // Získání všech možných barev písma.
            ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
            for (int i = 0; i < colors.Length; i++)
            {
                // Nastavení aktuální barvy písma.
                Console.ForegroundColor = colors[i];

                // Zobrazení čísla volby a názvu barvy.
                Console.WriteLine($"{i + 1}. {colors[i]}");
            }

            int choice = gc.GetChoice(colors.Length);
            // Získání vybrané barvy.
            ConsoleColor selectedColor = colors[choice - 1];

            // Nastavení vybrané barvy písma.
            Console.ForegroundColor = selectedColor;
            Console.WriteLine($"Zvolil jsi barvu: {selectedColor}");
            Thread.Sleep(1000);
            ShowSettingsMenu();
        }

        private void ShowColorsBackground()
        {
            Console.Clear();
            Console.WriteLine("Vyber si barvu pozadí:");
            Console.WriteLine("------------------------");

            ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
            for (int i = 0; i < colors.Length; i++)
            {
                Console.BackgroundColor = colors[i];
                Console.WriteLine($"{i + 1}. {colors[i]}");
            }


            int choice = gc.GetChoice(colors.Length);
            ConsoleColor selectedColor = colors[choice - 1];


            Console.BackgroundColor = selectedColor;
            Console.WriteLine($"Zvolil jsi barvu: {selectedColor}");
            Thread.Sleep(1000);
            ShowSettingsMenu();
        }
    }
}
