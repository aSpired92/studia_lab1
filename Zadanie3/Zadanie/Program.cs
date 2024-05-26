using System.Text;
namespace Zadanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\plik.txt";

            try
            {
                using(FileStream fstream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fstream)) 
                    {
                        while(!sr.EndOfStream)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
            }
        }
    }
}