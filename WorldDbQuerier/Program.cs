using System;
using MySql.Data.MySqlClient;
namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.2";

        static void Main(string[] args)
        {
            // Verwelkoming
            PrintHello();
            // Version -v
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-v":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Version {0}", version);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Onbekend argument");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
            // Menu
            PrintMenu();
            string Choice = Console.ReadLine();
            string SubChoice = "";
            if (Choice == "Country") {
                Console.WriteLine("Submenu: Make your choice:");
                Console.WriteLine("Count | List");
                SubChoice = Console.ReadLine();
                if (SubChoice == "Count") {
                    ConnectCountryCount();
                }
            }
        }

        static void PrintHello() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to WorldDbQuerier");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintMenu() {
            Console.WriteLine("Menu: Make your choice:");
            Console.WriteLine("Country | Region | Continent | SurfaceArea");
            Console.WriteLine("LifeExpentancy | Population | GovernmentForm");
        }

        static void ConnectCountryCount()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
                "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=imma;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT count(Name) FROM Country";

            conn.Open();

            int CountCountries = Convert.ToInt32(cmd.ExecuteScalar());

            Console.WriteLine("Total Countries: {0}", CountCountries);
        }
    }
}
