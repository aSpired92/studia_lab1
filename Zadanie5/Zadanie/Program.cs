using System.Runtime.CompilerServices;
using System.Text;
namespace Zadanie
{
    internal class Program
    {
        private static string path = @".\plik.bin";

        static void Main(string[] args)
        {
            while (true) 
            {
                int wybor = 0;

                while (wybor < 1 || wybor > 3)
                {
                    Console.WriteLine("1. Zapisz dane do pliku");
                    Console.WriteLine("2. Odczytaj dane z pliku");
                    Console.WriteLine("3. Wyjdź");

                    try
                    {
                        wybor = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    { continue; }
                }

                switch (wybor)
                {
                    case 1:
                        ZapiszDane();
                        break;
                    case 2:
                        OdczytajDane();
                        break;
                    default:
                        return;
                }
            }
        }

        private static void ZapiszDane() 
        {
            string imie;
            int wiek;
            string adres;

            Console.WriteLine("Podaj swoje imie");
            imie = Console.ReadLine();

            while(true)
            {
                Console.WriteLine("Podaj swój wiek");
                try
                {
                    wiek = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                { continue; }
            }

            Console.WriteLine("Podaj swój adres");
            adres = Console.ReadLine();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(imie);
                        bw.Write(wiek);
                        bw.Write(adres);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
            }
        }

        private static void OdczytajDane() 
        {
            string imie = "";
            int wiek = 0;
            string adres = "";

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        imie = br.ReadString();
                        wiek = br.ReadInt32();
                        adres = br.ReadString();
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
            }

            Console.WriteLine("Odczytane dane:");
            Console.WriteLine("Imie: " + imie);
            Console.WriteLine("Wiek: " + wiek);
            Console.WriteLine("Adres: " + adres);

            Console.ReadKey();
        }
    }
}