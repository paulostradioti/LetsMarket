using GetPass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Infrastructure
{
    internal static class ConsoleInput
    {
        public static int GetInt(string prompt)
        {
            Console.Write($"{prompt}: ");
            var input = Console.ReadLine();
            int.TryParse(input, out int value);

            return value;
        }

        public static string GetString(string prompt, string suggestion = "")
        {
            if (!string.IsNullOrEmpty(suggestion))
                suggestion = $" ({suggestion})";

            Console.Write($"{prompt}{suggestion}: ");
            var input = Console.ReadLine() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(input) && !string.IsNullOrWhiteSpace(suggestion))
                input = suggestion;

            return input;
        }

        public static string GetPassword(string prompt)
        {
            var password = ConsolePasswordReader.Read($"{prompt}: ");
            return password;
        }

        public static void WriteError(string message)
        {
            var original = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = original;

            Console.ResetColor();
        }
    }
}
