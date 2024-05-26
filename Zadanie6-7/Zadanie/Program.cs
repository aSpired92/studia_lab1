using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
namespace Zadanie
{
    internal class Program
    {
        static string inputPath = @"..\..\..\plik1.bin";
        static string outputPath = @"..\..\..\plik2.bin";

        static void Main(string[] args)
        {
            
            GenerateFile();
            Stopwatch sw = Stopwatch.StartNew();
            try
            {
                using (FileStream inputStream = new FileStream(inputPath, FileMode.Open))
                {
                    using (FileStream outputStream = new FileStream(outputPath, FileMode.Create))
                    {
                        using (BinaryReader brInput = new BinaryReader(inputStream))
                        {
                            using (BinaryWriter bwOutput = new BinaryWriter(outputStream))
                            {
                                while (brInput.BaseStream.Position != brInput.BaseStream.Length)
                                {
                                    bwOutput.Write(brInput.ReadBytes((int)brInput.BaseStream.Length));
                                }
                            }
                        }
                    }
                        
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Wystąpił błąd wejścia/wyjścia: {ex.Message}");
            }

            sw.Stop();
            Console.WriteLine("Kopiowanie zajeło: " + sw.Elapsed.Minutes + "m, " + sw.Elapsed.Seconds + "s, " + sw.Elapsed.Milliseconds + "ms");
            Console.ReadKey();
        }

        private static void GenerateFile()
        {
            byte[] buffer = new byte[314572800];
            Random rnd = new Random();

            rnd.NextBytes(buffer);

            using (FileStream fs = new FileStream(inputPath, FileMode.Create))
            {
                using (BinaryWriter bwOutput = new BinaryWriter(fs))
                {
                    bwOutput.Write(buffer);
                }
            }
        }
    }
}