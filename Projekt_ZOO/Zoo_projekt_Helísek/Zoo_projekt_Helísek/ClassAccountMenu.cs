using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace Zoo_projekt_Helísek
{
    class ClassAccountMenu
    {
        // Vytváří instance tříd ClassMainMenu a Funkce1.
        ClassMainMenu mainMenu = new ClassMainMenu();
        Funkce1 gc = new Funkce1();

        // Seznam pro uchovávání účtů.
        private List<ClassAccountsStorage> accounts = new List<ClassAccountsStorage>();

        // Konstruktor třídy, který načte účty ze souborů při vytvoření instance třídy.
        public ClassAccountMenu()
        {
            LoadAccountsFromFiles();
        }

        // Načítá účty ze souborů v aktuálním adresáři.
        private void LoadAccountsFromFiles()
        {
            // Získá všechny soubory s příponou .txt v aktuálním adresáři.
            string[] files = Directory.GetFiles(".", "*.txt");
            foreach (string file in files)
            {
                // Načte všechny řádky ze souboru.
                string[] lines = File.ReadAllLines(file);
                // Zkontroluje, zda soubor obsahuje alespoň dva řádky a začíná na "Ucet".
                if (lines.Length >= 2 && file.StartsWith(".\\Ucet"))
                {
                    string name = lines[0]; // První řádek Jméno
                    string password = lines[1]; // Druhý řádek Heslo
                    ClassAccountsStorage account = new ClassAccountsStorage(name, password, file); // Vytvoří novou instanci účtu a přidá ji do seznamu.
                    accounts.Add(account);
                }
            }
        }

        // Zobrazuje menu účtů.
        public void ShowAccountMenu()
        {
            Console.Clear();
            int accountNumber = 3; // Proměnná pro základní funkce

            Console.WriteLine("Účty:");
            Console.WriteLine("1. Založit nový");

            // Prochází seznam účtů a vypisuje je.
            foreach (ClassAccountsStorage ucet in accounts)
            {
                Console.Write("{0}. ", accountNumber-1);
                ucet.Vypis2(); // využije metodu Vypis2
                accountNumber++;
            }
            Console.WriteLine("{0}. Smazat účet", accountNumber-1);
            Console.WriteLine("{0}. Zpět", accountNumber);

            int choice = gc.GetChoice(accountNumber);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Vybral jsi Nový účet");
                    ShowNewAccount();
                    break;
                case int n when n == accountNumber:
                    Console.WriteLine("Vybral jsi Zpět");
                    mainMenu.ShowMainMenu();
                    break;
                case int n when n == accountNumber - 1:
                    Console.WriteLine("Vybral jsi Smazat účet");
                    SmazatAccount();
                    break;
                default:
                        Console.Clear();
                        ClassAccountsStorage selectedAccount = accounts[choice - 2]; // z listu vybere účet který je pod daným číslem
                        Console.WriteLine("Přihlašování k účtu {0}...", selectedAccount.GetName());
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Zadej heslo prosím:");
                        string heslo = Console.ReadLine(); // uživatel zadá heslo
                        if (heslo == selectedAccount.GetPassword()) // ověření hesla s tím co je v textovém souboru
                        {
                            Console.Clear();
                            Console.WriteLine("Hra začíná...");
                            Thread.Sleep(1000);
                            new ClassGame(selectedAccount.GetFilePath(),selectedAccount.GetName()).StartGame(); // spustí hru a pošle proměnný, které mu vyhodí metody GetFilePath a GetName
                        }
                        else
                        {
                            Console.WriteLine("Nesprávné heslo!");
                            Thread.Sleep(1000);
                            ShowAccountMenu();
                        }
                    break;
            }
        }
        private void SmazatAccount()
        {
            Console.Clear();
            Console.WriteLine("Účty:");
            for (int i = 0; i < accounts.Count; i++) // Vypíše všechny účty
            {
                Console.WriteLine("{0}. {1}", i + 1, accounts[i].GetName());
            }
            Console.WriteLine("{0}. Zpět", accounts.Count + 1);

            int choice = gc.GetChoice(accounts.Count + 1);

            if (choice > 0 && choice <= accounts.Count)
            {
                Console.Clear();
                ClassAccountsStorage smazatAccount = accounts[choice - 1];
                Console.WriteLine("Opravdu chceš smazat účet {0}? \n1. Ano \n2. Ne", smazatAccount.GetName());
                if (Console.ReadLine() == "1")
                {
                    accounts.RemoveAt(choice - 1); // Smaže z listu daný účet
                                                   // Smaže všechny složky s nim spjatý
                    string accountFilePath = smazatAccount.GetFilePath();
                    string accountDir = Path.GetDirectoryName(accountFilePath);

                    File.Delete(accountFilePath);
                    File.Delete(Path.Combine(accountDir, "KStavba" + smazatAccount.GetName() + ".txt"));
                    File.Delete(Path.Combine(accountDir, "VStavba" + smazatAccount.GetName() + ".txt"));
                    File.Delete(Path.Combine(accountDir, "PStavba" + smazatAccount.GetName() + ".txt"));
                    File.Delete(Path.Combine(accountDir, "Penize" + smazatAccount.GetName() + ".txt"));
                    File.Delete(Path.Combine(accountDir, "Rok" + smazatAccount.GetName() + ".txt"));
                    File.Delete(Path.Combine(accountDir, "Nakup" + smazatAccount.GetName() + ".txt"));
                    Console.WriteLine("Účet byl smazán.");
                    Thread.Sleep(1000);
                }
            }
            ShowAccountMenu();
        }
        private void ShowNewAccount()
        {
            Console.Clear();
            string[] files = Directory.GetFiles(".", "*.txt");
            Console.WriteLine("Nový účet.");
            Console.Write("Název: ");
            string name = Console.ReadLine().ToLower();
            // zkontroluje, zda účet již existuje.
            foreach (var file in files)
            {
                if (Path.GetFileNameWithoutExtension(file).ToLower() == "ucet"+name.ToLower()) // sežene jméno souboru bez přípony a zjístí jestli uživatel nenapsal stejný jméno jiné složky
                {
                    Console.Clear();
                    Console.WriteLine("Tento účet nemůžeš vytvořit.");
                    Thread.Sleep(1000);
                    ShowNewAccount();
                    return;
                }
            }

            Console.Write("Heslo: ");
            string password = Console.ReadLine();

            ClassAccountsStorage ucet = new ClassAccountsStorage(name, password, name + ".txt");   // Vytvoří novou instanci Třídy ClassAccountSorage s jménem, heslem a cestou k němu.
            accounts.Add(ucet); // uloží se do listu
            ucet.SaveToFile(); // využije metodu SavetoFile, do který pošle své proměnný a ona podle toho založí textové soubory a do nich hodnoty.
            ShowAccountMenu();
        }
    }
}
