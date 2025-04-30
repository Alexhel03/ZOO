using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace Zoo_projekt_Helísek
{
    class ClassAccountsStorage
    {
        private string name;
        private string password;
        private string filePath;

        public ClassAccountsStorage(string name, string password, string filePath) // konstruktor, který inicalizuje proměnný name, password, filePath
        {
            this.name = name;
            this.password = password;
            this.filePath = filePath;
        }

        public void Vypis2()
        {
            Console.WriteLine("Účet: {0}", name); // Metoda vypíše účet a jeho jméno
        }

        public string GetName()
        {
            return name; // metoda vrací proměnnou jméno
        }
        public string GetPassword()
        {
            return password;
        }
        public string GetFilePath()
        {
            return filePath; // metoda vrací cestu k souboru 
        }

        public void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter("Ucet" + filePath)) // Metoda vytvoří textový dokumenty a do každého zvlášť text co má.
            {
                sw.WriteLine(name);
                sw.WriteLine(password);
            }
            using (StreamWriter sw = new StreamWriter("KStavba"+filePath))
            {
                sw.WriteLine("0");

            }
            using (StreamWriter sw = new StreamWriter("PStavba" + filePath))
            {
                sw.WriteLine("0");
            }
            using (StreamWriter sw = new StreamWriter("VStavba" + filePath))
            {
                sw.WriteLine("0");
            }
            using (StreamWriter sw = new StreamWriter("Penize" + filePath))
            {
                sw.WriteLine("50000");
            }
            using (StreamWriter sw = new StreamWriter("Rok" + filePath))
            {
                sw.WriteLine("0,0");
            }
            using (StreamWriter sw = new StreamWriter("Nakup" + filePath))
            {
                sw.WriteLine("0");
            }
        }
    }
}
