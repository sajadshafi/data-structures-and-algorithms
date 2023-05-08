using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Helpers {
    public class Display {
        public static void Error(string message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Info(string message) {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Warning(string message) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public static void Success(string message) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void MainMenu(string message) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
