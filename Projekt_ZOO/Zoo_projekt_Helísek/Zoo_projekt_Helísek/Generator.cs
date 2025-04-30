using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_projekt_Helísek
{
    class Generator
    {
        private static string[] zvire = {"Lev", "Gorila", "Tygr", "Lemur", "Delfín", "Tučňák","Pelikán", "Papoušek","Aligátor","Kajman", "Žralok tygří", "Varan", "Slon", "Hroch", "Nosorožec","Žirafa","Zebra" }; // pole se zvířaty
        private static string[] jmeno = { "Alex", "Sam","Angel","Adrian", "Robin","Kája","Ariel"}; // pole s jmény
        private static string[] pohlavi = {"Samice", "Samec" }; // pole s pohlavím


        public static string GeneratorZvire()
        {
            var rnd = new Random(); // Vytvoříme metodu s random generátorem
            string randomZvire = zvire[rnd.Next(zvire.Length)]; // proměnná randomZvire využije pole se zvířaty, ze kterého potom metoda rnd vybere random číslo z pole, pod kterým je zvíře uloženo
            return randomZvire; // vrací výsledný text
        }
        public static string GeneratorJmeno() // funguje se stejně jako metoda GeneratorZvire
        {
            var rnd = new Random();
            string randomJmeno = jmeno[rnd.Next(jmeno.Length)];
            return randomJmeno;
        }
        public static string GeneratorPohlavi() // funguje se stejně jako metoda GeneratorZvire
        {
            var rnd = new Random();
            string randomPohlavi = pohlavi[rnd.Next(pohlavi.Length)];
            return randomPohlavi;
        }
        public static int GeneratorVek() // funguje se stejně jako metoda GeneratorZvire až na to že nečerpá z pole ale vybírá z parametru co jsme mu zadali
        {
            var rnd = new Random();
            int vek = rnd.Next(1, 6);
            return vek;
        }
        public static double GeneratorCena()// funguje se stejně jako metoda GeneratorVek
        {
            var rnd = new Random();
            double cena = rnd.Next(1000, 50000);
            return cena;
        }
    }
}
