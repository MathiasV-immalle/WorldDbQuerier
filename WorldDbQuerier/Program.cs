using System;

namespace WorldDbQuerier
{
    class Program
    {
        static string version = "0.1";

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to WorldDbQuerier");
            Console.ForegroundColor = ConsoleColor.White;
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
        }
    }
}
