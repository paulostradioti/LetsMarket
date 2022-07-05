using GetPass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket
{
    public static class ConsoleInput
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

        public static bool GetBoolean(string prompt, BooleanType type)
        {
            var opcoes = type switch
            {
                BooleanType.YN => "S/N",
                _ => "true/false"
            };

            Console.Write($"{prompt}? ({opcoes}) ");
            string input = Console.ReadLine() ?? string.Empty;

            if (type == BooleanType.YN)
            {
                if (input.ToLower() == "s")
                    input = "true";
                else 
                    input = "false";
            }

            return Convert.ToBoolean(input);
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
