using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Linq;

namespace Zoo_projekt_Helísek
{
    class ClassGame
    {
        ClassMainMenu menu = new ClassMainMenu();
        Funkce1 gc = new Funkce1();
        private string accountFilePath;
        private string name;
        // Konstruktor s dvěmi proměnnými
        public ClassGame(string accountFilePath, string name)
        {
            this.accountFilePath = "Ucet"+accountFilePath;
            this.name = name;
        }       
        // Hlavní metoda, která nám davá na výběr, jakou jinou metodu chceme využít.
        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("1. Chov zířat \n2. Nákup zvířat \n3. Prodej zvířat\n4. Stavba\n5. Množení\n6. Finance\n7. Další rok\n8. Zpátky/Konec");

            int choice = gc.GetChoice(8);

            switch (choice)
            {
                case 1:
                    Chov();
                    break;
                case 2:
                    Nakup();
                    break;
                case 3:
                    Prodej();
                    break;
                case 4:
                    Stavba();
                    break;
                case 5:
                    Mnozeni();
                    break;
                case 6:
                    Finance();
                    break;
                case 7:
                    DalsiRok();
                    break;
                case 8:
                    Konec();
                    break;
                default:
                    break;
            }
        }

        private void Chov() 
        {
            string filePath = accountFilePath; // vytvoří se proměnná s textem(cesta do souboru)
            Console.Clear();
            Console.WriteLine("Zvířata, která máš v ZOO:");
            string[] zvirata = File.ReadAllLines(filePath).Skip(2).ToArray(); // přečte všechny řádky v souboru a přeskočí dva první řádky zbytek roztřídí do pole
            for (int i = 0; i < zvirata.Length; i++)
            {
                var details = zvirata[i].Split(", "); // rozdělí podle čárky a mezery daný řádek, který je uložen pod číslem, které mu bylo přiřazeno a uloží je do pole řetězcu details
                string druh = details[0].Split(": ")[1]; // stane prakticky to samé, akorát že se rozděluje podle : a vybere 
                switch (druh)
                {
                    case "Varan":
                        Console.WriteLine(i + 1 + ". " + zvirata[i]+", 100 lidí/rok");
                        break;
                    case "Gorila":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 400 lidí/rok");
                        break;
                    case "Tygr":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 450 lidí/rok");
                        break;
                    case "Lemur":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 60 lidí/rok");
                        break;
                    case "Delfín":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 460 lidí/rok");
                        break;
                    case "Tučňák":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 70 lidí/rok");
                        break;
                    case "Pelikán":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 20 lidí/rok");
                        break;
                    case "Aligátor":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 250 lidí/rok");
                        break;
                    case "Kajman":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 230 lidí/rok");
                        break;
                    case "Žralok tygří":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 290 lidí/rok");
                        break;
                    case "Slon":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 500 lidí/rok");
                        break;
                    case "Hroch":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 480 lidí/rok");
                        break;
                    case "Nosorožec":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 550 lidí/rok");
                        break;
                    case "Žirafa":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 520 lidí/rok");
                        break;
                    case "Zebra":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 420 lidí/rok");
                        break;
                    case "Papoušek":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 15 lidí/rok");
                        break;
                    case "Monstrum":
                        Console.WriteLine(i + 1 + ". " + zvirata[i] + ", 10 000 lidí/rok");
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine(zvirata.Length+1 +". Zpět");
            while (true)
            {
                int choice = gc.GetChoice(zvirata.Length + 1);
                switch (choice)
                {
                    case int n when n == zvirata.Length + 1:
                        StartGame();
                        break;
                    default:
                        Console.WriteLine("Se zvířetem nelze nijak manipulovat.");
                        break;
                }
            }
        }

        private void Nakup()
        {
            // Načtení cesty k souboru účtu
            string filePath = accountFilePath;

            // Vytvoření seznamu pro zakoupená zvířata
            List<string> zakoupenaZvirata = new List<string>();

            // Sestavení názvů souborů pro jednotlivé typy staveb a nákupu
            string kStavba = "KStavba" + name + ".txt";
            string pStavba = "PStavba" + name + ".txt";
            string vStavba = "VStavba" + name + ".txt";
            string nakup = "Nakup" + name + ".txt";

            // Načtení počtu jednotlivých staveb
            int kStavbaCislo = Convert.ToInt32(File.ReadAllText(kStavba));
            int pStavbaCislo = Convert.ToInt32(File.ReadAllText(pStavba));
            int vStavbaCislo = Convert.ToInt32(File.ReadAllText(vStavba));

            // Načtení peněz uživatele
            string penize = "Penize" + name + ".txt";
            float penize2 = Convert.ToInt64(File.ReadAllText(penize));

            // proměnná pro celkovou cenu
            int suma = 0;
            string rok = "Rok" + name + ".txt";
            string rok2 = File.ReadAllText(rok);

            // Rozdělte řetězec podle čárky
            string[] rokHodnota = rok2.Split(',');

            // Rozdělení čísel ve složce do proměnných
            int rok3 = Convert.ToInt32(rokHodnota[0]);
            int rok4 = Convert.ToInt32(rokHodnota[1]);

            Console.Clear();
            Console.WriteLine("Zvířata v obchodě:");
            
            string[] zvire = new string[11];

            // Pokud jsou roky stejné, vygenerují se nová zvířata pro obchod
            if (rok3 == rok4)
            {
                for (int i = 0; i < 10; i++)
                {
                    zvire[i] = string.Format("Zvíře: {0}, Jméno: {1}, Pohlaví: {2}, Věk: {3}, Cena: {4}", Generator.GeneratorZvire(), Generator.GeneratorJmeno(), Generator.GeneratorPohlavi(), Generator.GeneratorVek(), Generator.GeneratorCena());
                    Console.WriteLine(i + 1 + ". " + zvire[i]);
                }
                zvire[10] = string.Format("Zvíře: Monstrum, Jméno Jožin z Bažin, Pohlaví: neznámý, Věk: neznámý, Cena: 60000");
                Console.WriteLine("11. Zvíře: Monstrum, Jméno: Jožin z Bažin, Pohlaví: neznámý, Věk: neznámý, Cena: 60000");
                
                // Aktualizace roku
                rok4 ++;
                using (StreamWriter sw = new StreamWriter(rok))
                {
                    sw.WriteLine(rok3 + "," + rok4);
                }

                // Uložení seznamu zvířat do souboru
                using (StreamWriter sw = new StreamWriter(nakup))
                {
                    for (int i = 0; i < zvire.Length; i++)
                    {
                        sw.WriteLine(zvire[i]);
                    }
                }

            }
            else
            {
                // Načtení zvířat ze souboru, pokud jsou roky různé
                string[] zvirata = File.ReadAllLines(nakup);
                for (int i = 0; i < zvirata.Length; i++)
                {
                    zvire[i] = zvirata[i]; 
                    Console.WriteLine(i+1+". "+zvirata[i]);
                }
            }
            

            Console.WriteLine("12. Zpět");
            while (true)
            {

                int choice = gc.GetChoice(12);
                switch (choice)
                {
                    case 12:
                        // Zpět, zobrazení celkové ceny a odečtení peněz
                        Console.WriteLine("Cena za zvířata " + suma);
                        Thread.Sleep(1000);
                        using (StreamWriter sw = new StreamWriter(penize))
                        {
                            sw.WriteLine(penize2-suma);
                        }
                        StartGame();
                        break;
                    default:
                        if (choice >= 1 && choice <= 11)
                        {
                            var details = zvire[choice - 1].Split(", ");
                            string druh = details[0].Split(": ")[1];
                            int cena = Convert.ToInt32(details[4].Split(": ")[1].Trim());
                            // Kontrola, zda už bylo zvíře zakoupeno
                            if (zakoupenaZvirata.Contains(zvire[choice - 1]))
                            {
                                Console.WriteLine("Nemůžeš si zakoupit dvakrát to stejné zvíře.");
                            }
                            else if (cena>penize2)
                            {
                                Console.WriteLine("Nemáš dostatek peněz");
                            }
                            else
                            {

                                // Kontrola typu zvířete a dostupnosti příslušné stavby
                                switch (druh)
                                {
                                    case "Varan":
                                    case "Gorila":
                                    case "Tygr":
                                    case "Lev":
                                    case "Lemur":
                                    case "Slon":
                                    case "Hroch":
                                    case "Nosorožec":
                                    case "Žirafa":
                                    case "Monstrum":
                                    case "Zebra":
                                        if (kStavbaCislo > 0)
                                        {
                                            using (StreamWriter sw = new StreamWriter(filePath, true))
                                            {
                                                sw.WriteLine(zvire[choice - 1]);
                                            }
                                            Console.WriteLine("Zakoupil si: " + zvire[choice - 1]);
                                            zakoupenaZvirata.Add(zvire[choice - 1]);
                                            suma += cena;
                                        }
                                        else
                                        {
                                            Console.WriteLine("K zakoupení potřebuješ klasický výběh!");
                                        }
                                        break;
                                    case "Delfín":
                                    case "Tučňák":
                                    case "Aligátor":
                                    case "Kajman":
                                    case "Žralok tygří":
                                        if (vStavbaCislo > 0)
                                        {
                                            using (StreamWriter sw = new StreamWriter(filePath, true))
                                            {
                                                sw.WriteLine(zvire[choice - 1]);
                                            }
                                            Console.WriteLine("Zakoupil si: " + zvire[choice - 1]);
                                            zakoupenaZvirata.Add(zvire[choice - 1]);
                                            suma += cena;
                                        }
                                        else
                                        {
                                            Console.WriteLine("K zakoupení potřebuješ vodní výběh!");
                                        }
                                        break;
                                    case "Pelikán":
                                    case "Papoušek":
                                        if (pStavbaCislo > 0)
                                        {
                                            using (StreamWriter sw = new StreamWriter(filePath, true))
                                            {
                                                sw.WriteLine(zvire[choice - 1]);
                                            }
                                            Console.WriteLine("Zakoupil si: " + zvire[choice - 1]);
                                            zakoupenaZvirata.Add(zvire[choice - 1]);
                                            suma += cena;
                                        }
                                        else
                                        {
                                            Console.WriteLine("K zakoupení potřebuješ ptačí výběh!");
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            }
                        }

                        break;

                }
            }
        }

        private void Prodej()
        {
            string filePath = accountFilePath;
            string penize = "Penize" + name + ".txt";
            float penize2 = Convert.ToInt64(File.ReadAllText(penize));
            int suma = 0;
            Console.Clear();
            Console.WriteLine("Zvířata, jaký můžeš prodat:");
            string[] zvirata = File.ReadAllLines(filePath).Skip(2).ToArray();
            for (int i = 0; i < zvirata.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + zvirata[i]);
            }
            Console.WriteLine(zvirata.Length + 1 + ". Zpět");
            while (true)
            {
                int choice = gc.GetChoice(zvirata.Length + 1);
                switch (choice)
                {
                    case int n when n == zvirata.Length + 1:
                        Console.WriteLine("Cena za zvířata " + suma);
                        Thread.Sleep(1000);
                        using (StreamWriter sw = new StreamWriter(penize))
                        {
                            sw.WriteLine(penize2 + suma);
                        }
                        StartGame();
                        break;
                    default:
                        // Vytvoření seznamu zvířat z pole
                        List<string> zvirataList = new List<string>(zvirata);

                        // Načtení a odstranění prodávaného zvířete ze seznamu
                        string prodaneZvire = zvirataList[choice-1];
                        zvirataList.RemoveAt(choice-1);

                        // Načtení všech řádků ze souboru účtu
                        var allLines = File.ReadAllLines(filePath).ToList();

                        // Aktualizace souboru účtu s novým seznamem zvířat (bez prodaného zvířete)
                        allLines = allLines.Take(2).Concat(zvirataList).ToList();
                        File.WriteAllLines(filePath, allLines);

                        Console.WriteLine("Prodal si: " + prodaneZvire);

                        // Získání ceny prodaného zvířete a aktualizace celkové získané sumy
                        var details = prodaneZvire.Split(", ");
                        int cena = Convert.ToInt32(details[4].Split(": ")[1].Trim());
                        suma += cena;

                        // Aktualizace pole zvířat po prodeji
                        zvirata = zvirataList.ToArray();
                        break;
                }

                Console.Clear();
                Console.WriteLine("Zvířata, jaký můžeš prodat:");
                for (int i = 0; i < zvirata.Length; i++)
                {
                    Console.WriteLine(i + 1 + ". " + zvirata[i]);
                }
                Console.WriteLine(zvirata.Length + 1 + ". Zpět");
            }
        }

        private void Stavba()
        {
            // Načtení cesty k souborům obsahujícím počet výběhů a peníze uživatele
            string kStavba = "KStavba" + name+".txt";
            string pStavba = "PStavba" + name + ".txt";
            string vStavba = "VStavba" + name + ".txt";

            // Načtení počtu výběhů z příslušných souborů
            int kStavbaCislo = Convert.ToInt32(File.ReadAllText(kStavba));
            int pStavbaCislo = Convert.ToInt32(File.ReadAllText(pStavba));
            int vStavbaCislo = Convert.ToInt32(File.ReadAllText(vStavba));
            string penize = "Penize" + name + ".txt";
            float penize2 = Convert.ToInt64(File.ReadAllText(penize));
            int suma = 0;
            Console.Clear();
            Console.WriteLine("Výběhy pro zvířata:");
            Console.WriteLine("1. Klasický výběh                                10 000");
            Console.WriteLine("2. Ptačí výběh                                   15 000");
            Console.WriteLine("3. Vodní výběh                                   20 000");
            Console.WriteLine("4. Zpět");

            while (true)
            {
                int choice = gc.GetChoice(4);

                switch (choice)
                {
                    case 1:
                        // Přidání ceny klasického výběhu k celkové částce
                        suma += 10000;
                        // Kontrola jestli má uživatel dostatek peněz
                        if (suma > penize2)
                        {
                            Console.WriteLine("Nemáš dostatek peněz");
                            suma -= 10000;
                        }
                        else
                        {
                            Console.WriteLine("Zakoupil si klasický výběh");
                            kStavbaCislo++;
                            using (StreamWriter sw = new StreamWriter(kStavba))
                            {
                                sw.WriteLine(kStavbaCislo);
                            }
                            
                        }
                        break;
                    case 2:
                        suma += 15000;
                        if (suma > penize2)
                        {
                            Console.WriteLine("Nemáš dostatek peněz");
                            suma -= 15000;
                        }
                        else
                        {


                            Console.WriteLine("Zakoupil si ptačí výběh");
                            pStavbaCislo++;
                            using (StreamWriter sw = new StreamWriter(pStavba))
                            {
                                sw.WriteLine(pStavbaCislo);
                            }
                        }
                        break;
                    case 3:
                        suma += 20000;
                        if (suma > penize2)
                        {
                            Console.WriteLine("Nemáš dostatek peněz");
                            suma -= 20000;
                        }
                        else
                        {
                            vStavbaCislo++;
                            Console.WriteLine("Zakoupil si Vodní výběh");
                            using (StreamWriter sw = new StreamWriter(vStavba))
                            {
                                sw.WriteLine(vStavbaCislo);
                            }
                        }
                        break;
                    case 4:
                        // Zobrazení celkové utracené částky a aktualizace souboru s penězi uživatele
                        Console.WriteLine("Útrata: "+suma);
                        Thread.Sleep(1000);
                        using (StreamWriter sw = new StreamWriter(penize))
                        {
                            sw.WriteLine(penize2 - suma);
                        }
                        StartGame();
                        break;
                    default:
                        break;
                }
            }
        }

        private void Mnozeni()
        {
            Console.Clear();
            string filePath = accountFilePath;
            string rok = "Rok" + name + ".txt";
            string rok2 = File.ReadAllText(rok);

            Console.WriteLine("Jaký zvířata chceš rozmnožit?");
            string[] zvirata = File.ReadAllLines(filePath).Skip(2).ToArray();
            for (int i = 0; i < zvirata.Length; i++)
            {
                Console.WriteLine(i + 1 + ". " + zvirata[i]);
            }
            Console.WriteLine(zvirata.Length + 1 + ". Zpět");
            while (true)
            {
                int choice = gc.GetChoice(zvirata.Length + 1);

                    switch (choice)
                    {
                        case int n when n == zvirata.Length + 1:
                            StartGame();
                            break;
                        default:
                            Console.WriteLine("Vyber další:");
                            int choice2 = gc.GetChoice(zvirata.Length + 1);
                            switch (choice2)
                            {
                                case int n when n == zvirata.Length + 1:
                                    StartGame();
                                    break;
                                default:
                                    if (OvereniMnozeni(zvirata[choice - 1], zvirata[choice2 - 1])) // Kontrola, zda jsou zvířata vhodná k rozmnožení
                                    {
                                        string pohlavi = Generator.GeneratorPohlavi(); // Vytvoření proměnný pohlaví, která využívá třídu Generator
                                        Console.WriteLine("Zvířata byla úspěšně rozmnožena! Narodil/a se " + pohlavi);
                                        Console.WriteLine("Napiš jak chceš, aby se mládě jmenovalo:");
                                        string jmeno = Console.ReadLine(); // Uživatel napíše jméno
                                        using (StreamWriter sw = new StreamWriter(filePath, true)) // Zápis zvířete do souboru
                                        {
                                            Console.WriteLine("Zvíře: {0}, Jméno: {1}, Pohlaví: {2}, Věk: {3}, Cena: {4}", zvirata[choice - 1].Split(", ")[0].Split(": ")[1], jmeno, pohlavi, "0", Generator.GeneratorCena());
                                            sw.WriteLine("Zvíře: {0}, Jméno: {1}, Pohlaví: {2}, Věk: {3}, Cena: {4}", zvirata[choice - 1].Split(", ")[0].Split(": ")[1], jmeno, pohlavi, "0", Generator.GeneratorCena());
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Zvířata nejsou vhodná pro rozmnožení.\nVyber jiná zvířata.");
                                    }
                                    break;
                            }
                            break;
                    }
            }
        }
        // Metoda pro ověření, zda jsou zvířata vhodná pro rozmnožení
        private bool OvereniMnozeni(string zvire1, string zvire2)
        {
            var details1 = zvire1.Split(", ");
            var details2 = zvire2.Split(", ");


            string druh1 = details1[0].Split(": ")[1]; // Vybere ze souboru "Zvíře: druh"
            string druh2 = details2[0].Split(": ")[1];
            string pohlavi1 = details1[2].Split(": ")[1]; // Vybere ze souboru "Pohlaví: pohlaví"
            string pohlavi2 = details2[2].Split(": ")[1];

            return druh1 == druh2 && pohlavi1 != pohlavi2; // pošle True nebo False, pokud jedna z podmínek nebudou platit
        }


        private void Finance()
        {
            Console.Clear();
            string penize = "Penize" + name + ".txt";
            float penize2 = Convert.ToInt64(File.ReadAllText(penize));
            string rok = "Rok" + name + ".txt";
            string rok2 = File.ReadAllText(rok);
            string filePath = accountFilePath;

            string[] rokHodnota = rok2.Split(',');

            int rok3 = Convert.ToInt32(rokHodnota[0]);

            // proměnná do který se bude zapisovat navštěvnost zvířat
            int navstevnost = 0;
           
            string[] zvirata = File.ReadAllLines(filePath).Skip(2).ToArray();
            
            // Rozdělí hodnoty zvířat podle druhu jakou mají návštěvnost, a potom přičte do proměnný navstevnost 
            for (int i = 0; i < zvirata.Length; i++)
            {
                if (zvirata[i] != "")
                {


                    var details = zvirata[i].Split(", ");
                    string druh = details[0].Split(": ")[1];
                    switch (druh)
                    {
                        case "Varan":
                            navstevnost += 100;
                            break;
                        case "Gorila":
                            navstevnost += 400;
                            break;
                        case "Tygr":
                            navstevnost += 450;
                            break;
                        case "Lemur":
                            navstevnost += 60;
                            break;
                        case "Delfín":
                            navstevnost += 460;
                            break;
                        case "Tučňák":
                            navstevnost += 70;
                            break;
                        case "Pelikán":
                            navstevnost += 20;
                            break;
                        case "Aligátor":
                            navstevnost += 250;
                            break;
                        case "Kajman":
                            navstevnost += 230;
                            break;
                        case "Žralok tygří":
                            navstevnost += 290;
                            break;
                        case "Slon":
                            navstevnost += 500;
                            break;
                        case "Hroch":
                            navstevnost += 480;
                            break;
                        case "Nosorožec":
                            navstevnost += 550;
                            break;
                        case "Žirafa":
                            navstevnost += 520;
                            break;
                        case "Zebra":
                            navstevnost += 420;
                            break;
                        case "Papoušek":
                            navstevnost += 15;
                            break;
                        case "Monstrum":
                            navstevnost += 10000;
                            break;
                        default:
                            break;
                    }
                }
            }
            int listek = 20;
            // Vypíše hodnoty
            Console.WriteLine("1. Roční návštěvnost: "+navstevnost+"/rok");
            Console.WriteLine("2. Potencionální výdělek: "+listek*navstevnost+"/rok");
            Console.WriteLine("3. Cena lístku: " + listek);
            Console.WriteLine("4. Peníze na učtě: " + penize2);
            Console.WriteLine("5. Rok: " + rok3);
            Console.WriteLine("6. Zpět");
            while (true)
            {
                int choice = gc.GetChoice(6);

                if (choice == 6)
                {
                    StartGame();
                    break;
                }
                else
                {
                    Console.WriteLine("Nelze vybrat!");
                }
            }
        }

        private void DalsiRok()
        {
            Console.Clear();
            string filePath = accountFilePath;
            Console.WriteLine("Opravdu si přeješ přeskočit rok?\n1. Ano\n2. Ne");
            string[] zvirata = File.ReadAllLines(filePath).Skip(2).ToArray();

            // Stane se to sámé co v metodě Finance
            int navstevnost = 0;

            for (int i = 0; i < zvirata.Length; i++)
            {
                var details = zvirata[i].Split(", ");
                string druh = details[0].Split(": ")[1];
                switch (druh)
                {
                    case "Varan":
                        navstevnost += 100;
                        break;
                    case "Gorila":
                        navstevnost += 400;
                        break;
                    case "Tygr":
                        navstevnost += 450;
                        break;
                    case "Lemur":
                        navstevnost += 60;
                        break;
                    case "Delfín":
                        navstevnost += 460;
                        break;
                    case "Tučňák":
                        navstevnost += 70;
                        break;
                    case "Pelikán":
                        navstevnost += 20;
                        break;
                    case "Aligátor":
                        navstevnost += 250;
                        break;
                    case "Kajman":
                        navstevnost += 230;
                        break;
                    case "Žralok tygří":
                        navstevnost += 290;
                        break;
                    case "Slon":
                        navstevnost += 500;
                        break;
                    case "Hroch":
                        navstevnost += 480;
                        break;
                    case "Nosorožec":
                        navstevnost += 550;
                        break;
                    case "Žirafa":
                        navstevnost += 520;
                        break;
                    case "Zebra":
                        navstevnost += 420;
                        break;
                    case "Papoušek":
                        navstevnost += 15;
                        break;
                    case "Monstrum":
                        navstevnost += 10000;
                        break;
                    default:
                        break;
                }

            }
            int choice = gc.GetChoice(2);

            if (choice == 1)
            {
                // Ze souboru přečte a rozdělí číslo, které bude představovat rok a přičte k němu 1 a následně zapíše do souboru
                string rok = "Rok" + name + ".txt";
                string rok2 = File.ReadAllText(rok);
                string[] rokHodnota = rok2.Split(',');
                int rok3 = Convert.ToInt32(rokHodnota[0])+1;
                int rok4 = Convert.ToInt32(rokHodnota[1]);
                string penize = "Penize" + name + ".txt";
                float penize2 = Convert.ToInt64(File.ReadAllText(penize));
                using (StreamWriter sw = new StreamWriter(rok))
                {
                    sw.WriteLine(rok3+","+rok4);
                }
                // Do souboru, který má hodnotu peněz přičte kolik uživateli vydělala Zoo
                using (StreamWriter sw = new StreamWriter(penize))
                {
                    sw.WriteLine(penize2 + navstevnost*20);
                }
                // Přečte řádky souboru se zvířaty a rozdělí je podle věku, ke kterým následně přičte 1 a zapíše 
                var newLines = new List<string>(File.ReadAllLines(filePath).Take(2));
                for (int i = 0; i < zvirata.Length; i++)
                {
                    var details = zvirata[i].Split(", ");
                    int vek = Convert.ToInt32(details[3].Split(": ")[1]);
                    int novyVek = vek + 1;
                    details[3] = "Věk: " + novyVek;
                    newLines.Add(string.Join(", ", details));
                }
                File.WriteAllLines(filePath, newLines);

                StartGame();
            }
            else
            {
                StartGame();
            }
        }

        private void Konec()
        {
            Console.Clear();
            Console.WriteLine("Chceš se vrátit do menu nebo ukončit hru? \n1. Zpět do menu \n2. Ukončit \n3. Zpět");
            int choice = gc.GetChoice(3);
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Opravdu se cheš vrátit?");
                    Console.WriteLine("1. Ano\n2. Ne");
                    int choice2 = gc.GetChoice(2);
                    if (choice2 == 2)
                    {
                        Konec();
                    }
                    else
                    {
                        // vrátí se do třídy menu do metody ShowMainMenu
                        menu.ShowMainMenu();
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Opravdu cheš Ukončit hru?");
                    Console.WriteLine("1. Ano\n2. Ne");
                    int choice3 = gc.GetChoice(2);
                    if (choice3 == 2)
                    {
                        Konec();
                    }
                    else
                    {
                        // Ukončí hru
                        Environment.Exit(0);
                    }
                    break;
                case 3:
                    StartGame();
                    break;
                default:
                    break;
            }
        }
    }
}
