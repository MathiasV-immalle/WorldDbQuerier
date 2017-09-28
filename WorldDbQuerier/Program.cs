using System;
using MySql.Data.MySqlClient;
namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.2";

        static void Main(string[] args)
        {
            PrintVerwelkoming();
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
            PrintMenu();
            MaakConnectie();
        }

        static void PrintVerwelkoming() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to WorldDbQuerier");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintMenu() {
            Console.WriteLine("Menu:");
            Console.WriteLine("menu coming");
        }

        static void MaakConnectie()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString =
                "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=imma;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT count(Name) FROM Country";

            conn.Open();

            int AantalLanden = Convert.ToInt32(cmd.ExecuteScalar());

            Console.WriteLine("Aantal landen : {0}", AantalLanden);
        }
    }
}
