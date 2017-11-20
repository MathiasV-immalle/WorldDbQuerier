using System;
using MySql.Data.MySqlClient;
namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.3";

        static void Main(string[] args)
        {
            // Verwelkoming
            PrintHello();
            VraagInfo();
            // Version -v
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "-v":
                    case "--version":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Version {0}", version);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case "-h":
                    case "--help":
                        Console.WriteLine("-v, --version : Display program version");
                        Console.WriteLine("-h, --help: Display help information");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Onbekend argument");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            int exit = 0;
            while (exit == 0)
            {
                // Menu
                PrintMenu();
                string Choice = Console.ReadLine();
                Choice = Choice.ToLower();
                string SubChoice = "";

                switch (Choice)
                {
                    case "country":
                    case "1":
                        PrintSubmenu();
                        SubChoice = Console.ReadLine();
                        SubChoice = SubChoice.ToLower();
                        switch (SubChoice)
                        {
                            case "count":
                            case "1":
                                ConnectCountryCount();
                                break;
                            case "list":
                            case "2":
                                ConnectCountryList();
                                break;
                            case "search":
                            case "3":
                                ConnectCountrySearch();
                                break;
                            case "searchall":
                            case "4":
                                ConnectCountrySearchAll();
                                break;
                            case "69":
                            case "0":
                            case "21":
                                WeirdItemException();
                                break;
                            case "":
                                PrintNoChoiceError();
                                break;
                            default:
                                PrintChoiceError();
                                break;
                        }
                        break;
                    case "quit":
                        exit = 1;
                        break;
                    case "69":
                    case "0":
                    case "21":
                        WeirdItemException();
                        break;
                    case "":
                        PrintNoChoiceError();
                        break;
                    default:
                        PrintChoiceError();
                        break;
                }
            }
        }

        static string Underline(string str)
        {
            string line = "";
            int length = str.Length;
            while (length != 1)
            {
                line += "-";
                length -= 1;
            }
            line += "-";
            return line;
        }

        static void VraagInfo()
        {
            Console.WriteLine("Password:");
            string password = Console.ReadLine();
            Console.WriteLine("Username:");
            string username = Console.ReadLine();
            Console.WriteLine("IP-adress:");
            string ipadress = Console.ReadLine();
        }

        static void PrintHello() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string welcome = "Welcome to WorldDbQuerier";
            Console.WriteLine(Underline(welcome));
            Console.WriteLine(welcome);
            Console.WriteLine(Underline(welcome));
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintMenu() {
            string print = "Menu:";
            Console.WriteLine(print);
            Console.WriteLine(Underline(print));
            string menu1 = "1) Country 2) Region 3) Continent 4) SurfaceArea";
            string menu2 = "5) LifeExpentancy 6) Population 7) GovernmentForm 8) QUIT";
            Console.WriteLine(menu1);
            Console.WriteLine(menu2);
        }

        static void PrintSubmenu() {
            string submenuOnderlijnd = "Submenu:";
            string submenu = "1) Count 2) List 3) Search 4) SearchAll";
            Console.WriteLine(Underline(submenuOnderlijnd));
            Console.WriteLine(submenuOnderlijnd);
            Console.WriteLine(Underline(submenuOnderlijnd));
            Console.WriteLine(submenu);
        }

        static void PrintNoChoiceError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Gelieve een keuze in te voeren");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintChoiceError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Gelieve te kiezen uit bovenstaande items");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void WeirdItemException()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Don't you dare to try again :[");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ConnectCountryCount()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=imma;";
            Console.WriteLine("Connecting to MySQL...");
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT count(Name) FROM Country";
            conn.Open();
            int CountCountries = Convert.ToInt32(cmd.ExecuteScalar());
            string total = "Total Countries: ";
            string amount = total + CountCountries.ToString();
            Console.WriteLine(Underline(amount));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(total + "{0}", CountCountries);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Underline(amount));
        }

        static void ConnectCountryList()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=imma;";
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            Console.WriteLine("---");
            string sql = "SELECT Name FROM Country";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            int teller = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            while (rdr.Read())
            {
                Console.WriteLine(Convert.ToString(teller) + ": " + rdr[0]);
                teller++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---");
        }

        static void ConnectCountrySearchAll()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=imma;";
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            Console.WriteLine("---");
            string sql = "SELECT * FROM Country";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            int teller = 1;
            Console.ForegroundColor = ConsoleColor.Green;
            while (rdr.Read())
            {
                Console.WriteLine(Convert.ToString(teller) + ": " + rdr[0] + " | " + rdr[1] + " | " + rdr[2] + " | " + rdr[3]+ " | " + rdr[4] + " | " + rdr[5] + " | " + rdr[6] + " | " + rdr[7] + " | " + rdr[8] + " | " + rdr[9] + " | " + rdr[10] + " | " + rdr[11] + " | " + rdr[12] + " | " + rdr[13] + " | " + rdr[14]);
                teller++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---");
        }

        static void ConnectCountrySearch()
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=192.168.56.101;Port=3306;Database=world;Uid=imma;Pwd=imma;";
            Console.WriteLine("Type country name:");
            string name = Console.ReadLine();
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
            Console.WriteLine("---");
            string sql = "SELECT * FROM Country WHERE Name LIKE @name";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@name", "%" + name + "%");
            MySqlDataReader rdr = cmd.ExecuteReader();
            Console.ForegroundColor = ConsoleColor.Green;
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " | " + rdr[1] + " | " + rdr[2] + " | " + rdr[3] + " | " + rdr[4] + " | " + rdr[5] + " | " + rdr[6] + " | " + rdr[7] + " | " + rdr[8] + " | " + rdr[9] + " | " + rdr[10] + " | " + rdr[11] + " | " + rdr[12] + " | " + rdr[13] + " | " + rdr[14]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---");
        }
    }
}
