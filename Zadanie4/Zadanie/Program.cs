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
                            string temp = sr.ReadLine();

                            for(int i=temp.Length-1; i>=0; i--)
                            {
                                Console.Write(temp[i]);
                            }

                            Console.WriteLine();
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