using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_projekt_Helísek
{
    class Funkce1
    {
        // Metoda GetChoice přijímá maximální hodnotu výběru jako parametr (maxChoice)
        public int GetChoice(int maxChoice)
        {
            // Smyčka while pokračuje, dokud není vstup od uživatele platné celé číslo
            // a zároveň musí být v rozsahu od 1 do maxChoice
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice)
            {
                // Pokud vstup není platný, vypíše se tato zpráva
                Console.WriteLine($"Prosím vyber číslo mezi 1 a {maxChoice}.");
            }
            return choice;
        }
    }
}
