using System.Text.Json;

namespace Projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenadzerZadan menadzer = MenadzerZadan.Instance;

            bool exit = false;
            while (!exit)
            {
                switch (MainMenu())
                {
                    case '1':
                        {
                            Console.Clear();
                            ShowTasks();
                            break;
                        }
                    case '2':
                        {
                            Console.Clear();
                            AddTask();
                            break;
                        }
                    case '3':
                        {
                            Console.Clear();
                            SaveFile();
                            break;
                        }
                    case '4':
                        {
                            Console.Clear();
                            LoadFile();
                            break;
                        }
                    default:
                        {
                            exit = true;
                            break;
                        }
                }
            }
        }

        private static char MainMenu()
        {
            char choice = '\0';

            while (true)
            {
                Console.WriteLine("1. Wyświetl listę zadań");
                Console.WriteLine("2. Dodaj zadanie");
                Console.WriteLine("3. Zapisz zadania do pliku");
                Console.WriteLine("4. Wczytaj zadania z pliku");
                Console.WriteLine("5. Wyjdź");

                choice = Console.ReadKey().KeyChar;

                if (choice >= '1' && choice <= '5')
                {
                    return choice;
                }

                Console.Clear();
            }
        }

        private static void ShowTasks()
        {
            while (true)
            {
                MenadzerZadan menadzer = MenadzerZadan.Instance;

                Console.WriteLine("Wpisz numer zadania by sprawdzić jego szczegóły.");
                Console.WriteLine("Wpisz 'S' aby zmienić ustawienie sortowania.");
                Console.WriteLine("Wpisz 'E' aby wrócić się do poprzedniego menu.\n");
                Console.WriteLine("Twoja lista zadań:");

                menadzer.PokazZadania();
                int choice = 0;
                string input = Console.ReadLine().ToLower();

                Console.Clear();

                if (input.Equals("e"))
                {
                    break;
                }

                if (input.Equals("s"))
                {
                    SortTasks();
                    Console.Clear();
                    continue;
                }

                try
                {
                    choice = int.Parse(input) - 1;
                }
                catch
                {
                    continue;
                }

                if (choice < 0 || choice >= menadzer.LiczbaZadan)
                {
                    continue;
                }

                ShowTask(choice);

                Console.Clear();
            }
        }

        private static void SortTasks()
        {
            while (true)
            {
                Console.WriteLine("Wpisz numer aby wybrać metodę sortowania.");
                Console.WriteLine("Wpisz 'E' aby wrócić się do poprzedniego menu.\n");

                Console.WriteLine("1. Nazwa - rosnąco");
                Console.WriteLine("2. Nazwa - malejąco");
                Console.WriteLine("3. Data utworzenia - rosnąco");
                Console.WriteLine("4. Data utworzenia - malejąco");
                Console.WriteLine("5. Data zakończenia - rosnąco");
                Console.WriteLine("6. Data zakończenia - malejąco");

                char choice = Console.ReadKey().KeyChar;

                if(choice == 'e' || choice == 'E')
                {
                    break;
                }

                if (choice >= '1' && choice <= '6')
                {
                    switch (choice)
                    {
                        case '1': choice = 'n'; break;
                        case '2': choice = 'N'; break;
                        case '3': choice = 'd'; break;
                        case '4': choice = 'D'; break;
                        case '5': choice = 'z'; break;
                        case '6': choice = 'Z'; break;
                    }

                    MenadzerZadan.Instance.Sortuj(choice);
                    break;
                }

                Console.Clear();
            }
        }

        private static void ShowTask(int id)
        {
            bool exit = false;
            while (!exit)
            {
                MenadzerZadan menadzer = MenadzerZadan.Instance;
                Console.WriteLine("Wpisz 'C' aby oznaczyć zadanie jako wykonane.");
                Console.WriteLine("Wpisz 'D' aby usunąć zadanie.");
                Console.WriteLine("Wpisz 'E' aby wrócić się do poprzedniego menu.\n");

                menadzer.PokazZadanie(id);

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case 'c':
                    case 'C':
                        {
                            menadzer.WykonajZadanie(id);
                            break;
                        }
                    case 'd':
                    case 'D':
                        {
                            menadzer.UsunZadanie(id);
                            exit = true;
                            break;
                        }
                    case 'e':
                    case 'E':
                        {
                            exit = true;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                Console.Clear();
            }
        }

        private static void AddTask()
        {
            string? name = "";
            string? description = "";

            while (name == null || name.Equals(""))
            {
                Console.WriteLine("Podaj nazwę zadania:");
                name = Console.ReadLine();
                Console.Clear();
            }

            while (description == null || description.Equals(""))
            {
                Console.WriteLine("Podaj nazwę zadania:");
                description = Console.ReadLine();
                Console.Clear();
            }
        }

        private static void SaveFile()
        {
            if(!MenadzerZadan.Instance.ZapiszZadania())
            {
                Console.WriteLine("Nie udało się zapisać zadań.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void LoadFile()
        {
            if (!MenadzerZadan.Instance.WczytajZadania())
            {
                Console.WriteLine("Nie udało się wczytać zadań.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}