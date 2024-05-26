using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Projekt
{
    public class MenadzerZadan
    {
        private static MenadzerZadan instance;
        public static MenadzerZadan Instance 
        {
            get 
            {
                if(instance == null)
                {
                    instance = new MenadzerZadan();
                }

                return instance;
            }
        }


        private static string path = @"./zadania.json";

        public List<Zadanie> listaZadan { get; private set; } = new List<Zadanie>();

        [JsonIgnore]
        public int LiczbaZadan
        {
            get { return listaZadan.Count; }
        }
           
        private MenadzerZadan() { }

        public void DodajZadanie(Zadanie zadanie) 
        {
            listaZadan.Add(zadanie);
        }

        public void WykonajZadanie(int index)
        {
            listaZadan[index].DataZakonczenia = DateTime.Now;
        }

        public void UsunZadanie(int index)
        {
            listaZadan.RemoveAt(index);
        }

        public void PokazZadania()
        {
            for (int i=0; i<listaZadan.Count; i++)
            {
                Zadanie z = listaZadan[i];
                string czyWykonane = " [" + (z.CzyWykonane ? "X" : " ") + "]";

                Console.WriteLine(i+1 + ". " + z.Nazwa + czyWykonane);
            }
        }

        public void PokazZadanie(int index)
        {
            Zadanie z = listaZadan[index];
            string strDataWykonania = z.CzyWykonane ? "Tak - " + z.DataZakonczenia.Value.ToShortDateString() : "Nie";

            Console.WriteLine("Nazwa          : " + z.Nazwa);
            Console.WriteLine("Opis           : " + z.Opis);
            Console.WriteLine("Data utworzenia: " + z.DataDodania.ToShortDateString());
            Console.WriteLine("Czy wykonane   : " + strDataWykonania);
        }

        public void Sortuj(char sposob)
        {
            switch (sposob) 
            {
                case 'n':
                    {
                        listaZadan = listaZadan.OrderBy(z => z.Nazwa).ToList();
                        break;
                    }
                case 'N':
                    {
                        listaZadan = listaZadan.OrderBy(z => z.Nazwa).Reverse().ToList();
                        break;
                    }
                case 'd':
                    {
                        listaZadan = listaZadan.OrderBy(z => z.DataDodania).ToList();
                        break;
                    }
                case 'D':
                    {
                        listaZadan = listaZadan.OrderBy(z => z.DataDodania).Reverse().ToList();
                        break;
                    }
                case 'z':
                    {
                        listaZadan = listaZadan.OrderBy(z => z.DataZakonczenia).ToList();
                        break;
                    }
                case 'Z':
                    {
                        listaZadan = listaZadan.OrderBy(z => z.DataZakonczenia).Reverse().ToList();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public bool ZapiszZadania()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
                    string str = JsonSerializer.Serialize(listaZadan, options);
                    sw.Write(str);
                }

                return true;
            } 
            catch 
            {
                return false;
            }
        }

        public bool WczytajZadania()
        {
            try
            {
                string jsonString = File.ReadAllText(path);

                listaZadan = JsonSerializer.Deserialize<List<Zadanie>>(jsonString)!;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
