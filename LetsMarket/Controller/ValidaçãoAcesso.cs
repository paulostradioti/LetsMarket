using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket
{
    public class ValidaçãoAcesso
    {
        public static void VerificaLogin()
        {
            var loggedIn = false;
            var attempts = 0;

            do
            {
                attempts++;
                Console.Clear();

                if (attempts > 1)
                {
                    Console.WriteLine(Environment.NewLine);
                    ConsoleInputLogin.WriteError("DADOS INCORRETOS");
                    Console.WriteLine(Environment.NewLine);
                }

                Console.WriteLine("SISTEMA DE LOGIN");

                var username = ConsoleInputLogin.GetString("login");
                var password = ConsoleInputLogin.GetPassword("senha");

                if (LoginIsValid(username, password))
                {
                    loggedIn = true;
                    Database.Funcionarios.Remove(new Funcionario { Nome = "Admin", Login = "admin", Password = "admin" });
                    //Sugerir criação do método Remover e Adicionar no Database
                }                    
            } while (!loggedIn);

        }

        private static bool LoginIsValid(string? username, string password)
        {
            foreach (var user in Database.Funcionarios)
            {
                if (user.Login.ToLower() == username.ToLower() && user.Password == password)
                    return true;
            }

            return false;
        }
        
    }
}
