using System;

namespace WonderKingNA.Tools {
    internal class Log {
        public static void ConsoleMessage(string msg) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
        }

        public static void ConsoleWarning(string msg) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
        }

        public static void ConsoleError(string msg) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
        }

        public static void ConsoleTest() {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[TEST][{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Testing.");
        }

        public static void ConsoleTest(string msg) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[TEST][{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(msg);
        }

        public static void ConsoleTest(int msg) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[TEST][{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(msg);
        }

        public static void ConsoleTest(string msg, string msg2, string msg3) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[TEST][{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(msg, msg2, msg3);
        }

        public static void ConsoleMessage(string msg, ConsoleColor color) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = color;
            Console.WriteLine(msg);
        }

        public static void ConsoleError(string msg, params object[] args) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
        }

        public static void ConsoleMessage(string msg, params object[] args) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg, args);
        }

        public static void ConsoleMessage(string msg, ConsoleColor color, params object[] args) {
            DateTime time = DateTime.Now;
            string displayTime = time.ToString("hh:mm tt");
            string date = time.ToString("ddd, MMM d");

            Console.Title = "WonderKing Online";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[{0}][{1}]\t", displayTime, date);
            Console.ForegroundColor = color;
            Console.WriteLine(msg, args);
        }
    }
}
