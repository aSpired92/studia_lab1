using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie
{
    internal class Garaz
    {
        private string adres = "";
        private int pojemnosc = 0;
        private int liczbaSamochodow = 0;

        private Samochod[] samochody;

        public string Adres
        {
            get { return adres; }
            set { adres = value; }
        }
        public int Pojemnosc
        {
            get { return pojemnosc; }
            set 
            { 
                pojemnosc = value;
                samochody = new Samochod[value];
            }
        }

        public Garaz() 
        {
            adres = "nieznany";
            pojemnosc = 0;

            samochody = null;
        }   

        public Garaz(string adres_, int pojemnosc_)
        {
            adres = adres_;
            pojemnosc = pojemnosc_;

            samochody = new Samochod[pojemnosc_];
        }

        public void WprowadzSamochod(Samochod samochod)
        {
            if (liczbaSamochodow >= pojemnosc)
            {
                Console.WriteLine("Garaż jest pełny.");
                return;
            }

            samochody[liczbaSamochodow++] = samochod;

        }

        public void WyprowadzSamochod()
        {
            if (liczbaSamochodow <= 0)
            {
                Console.WriteLine("Garaż jest pusty.");
                return;
            }

            samochody[(liczbaSamochodow--)-1] = null;

        }

        public void WypiszInfo()
        {
            Console.WriteLine("Adres: " + Adres);
            Console.WriteLine("Pojemnosc: " + pojemnosc);
            Console.WriteLine("Aktualnie przechowywane pojazdy: ");

            for (int i = 0; i < liczbaSamochodow; i++)
            {
                samochody[i].WypiszInfo();
                Console.WriteLine("==========");
            }
        }
    }
}
