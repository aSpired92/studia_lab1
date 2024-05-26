using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
    public class Zadanie
    {
        private static uint zadanieCount = 0;

        public uint Id { get; private set; } = 0;
        public string Nazwa { get; set; } = "";
        public string Opis { get; set; } = "";
        public DateTime DataDodania { get; private set; }
        public DateTime? DataZakonczenia { get; set; } = null;

        [JsonIgnore]
        public bool CzyWykonane
        {
            get { return DataZakonczenia != null; }
        }

        public Zadanie() 
        {
            Id = zadanieCount++;

            DataDodania = DateTime.Now;
        }

        public Zadanie(string nazwa, string opis)
        {
            Id = zadanieCount++;

            Nazwa = nazwa;
            Opis = opis;

            DataDodania = DateTime.Now;
        }

        public Zadanie(uint id, string nazwa, string opis, DateTime dataDodania, DateTime? dataZakonczenia)
        {
            Id = id;
            
            Nazwa = nazwa;
            Opis = opis;
            DataDodania = dataDodania;
            DataZakonczenia = dataZakonczenia;

            if (zadanieCount <= id)
            {
                zadanieCount = id + 1;
            }
        }
    }
}
