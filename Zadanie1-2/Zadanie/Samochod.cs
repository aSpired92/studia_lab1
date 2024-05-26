namespace Zadanie
{
    internal class Samochod
    {
        private static int liczbaSamochodów = 0;

        private string marka = "";
        private string model = "";

        private int iloscDrzwi = 0;
        private int pojemnoscSilnika = 0;
        private double srednieSpalanie = 0;

        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int IloscDrzwi
        {
            get { return iloscDrzwi; }
            set { iloscDrzwi = value; }
        }
        public int PojemnoscSilnika
        {
            get { return pojemnoscSilnika; }
            set { pojemnoscSilnika = value; }
        }
        public double SrednieSpalanie
        {
            get { return srednieSpalanie; }
            set { srednieSpalanie = value; }
        }

        public Samochod() 
        {
            marka = "nieznana";
            model = "nieznany";
            iloscDrzwi = 0;
            pojemnoscSilnika = 0;
            srednieSpalanie = 0.0;

            liczbaSamochodów++;
        }

        public Samochod(string marka_, string model_, int iloscDrzwi_, int pojemnoscSilnika_, double srednieSpalanie_)
        {
            marka = marka_;
            model = model_;
            iloscDrzwi = iloscDrzwi_;
            pojemnoscSilnika = pojemnoscSilnika_;
            srednieSpalanie = srednieSpalanie_;

            liczbaSamochodów++;
        }

        private double ObliczSpalanie(double dlugoscTrasy)
        {
            return srednieSpalanie * dlugoscTrasy / 100.0; ;
        }

        public double ObliczKosztPrzejazdu(double dlugoscTrasy, double cenaPaliwa) 
        {
            return ObliczSpalanie(dlugoscTrasy) * cenaPaliwa;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Marka: " + marka);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Ilość Drzwi: " + iloscDrzwi);
            Console.WriteLine("Pojemność Silnika: " + pojemnoscSilnika);
            Console.WriteLine("Średnie Spalanie: " + srednieSpalanie);
        }

        public static void WypiszIloscSamochodow()
        {
            Console.WriteLine("Ilość Samochodów: " + liczbaSamochodów);
        }
    }
}
