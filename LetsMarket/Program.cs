using BetterConsoleTables;
using GetPass;
using Sharprompt;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LetsMarket
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConfiguraPrompt();
            Console.Title = "Let's Store";



            //VerificaLogin();

            var menu = new MenuItem("Menu Principal");

            var produtos = new MenuItem("Produtos");
            produtos.Add(new MenuItem("Cadastrar Produtos", Produtos.CadastrarProdutos));
            produtos.Add(new MenuItem("Listar Produtos", Produtos.ListarProdutos));

            var funcionarios = new MenuItem("Funcionários");
            funcionarios.Add(new MenuItem("Cadastrar Funcionários", Funcionario.CadastrarFuncionarios));
            funcionarios.Add(new MenuItem("Listar Funcionários", Funcionario.ListarFuncionarios));
            funcionarios.Add(new MenuItem("Editar Funcionários", Funcionario.EditarFuncionario));
            funcionarios.Add(new MenuItem("Remover Funcionários", Funcionario.RemoverFuncionario));

            var submenu = new MenuItem("Submenu");
            submenu.Add(new MenuItem("item do submenu"));

            menu.Add(produtos);
            menu.Add(funcionarios);
            menu.Add(submenu);

            menu.Execute();
        }

        private static void ConfiguraPrompt()
        {
            Prompt.ColorSchema.Answer = ConsoleColor.White;
            Prompt.ColorSchema.Select = ConsoleColor.White;

            Prompt.Symbols.Prompt = new Symbol("", "");
            Prompt.Symbols.Done = new Symbol("", "");
            Prompt.Symbols.Error = new Symbol("", "");
            
        }

        private static void VerificaLogin()
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
                    ConsoleInput.WriteError("DADOS INCORRETOS");
                    Console.WriteLine(Environment.NewLine);
                }

                Console.WriteLine("SYSTEM LOGIN");
                
                var username = ConsoleInput.GetString("login");
                var password = ConsoleInput.GetPassword("senha");

                if (LoginIsValid(username, password))
                    loggedIn = true;
                   
            } while (!loggedIn);
            
        }

        private static bool LoginIsValid(string? username, string password)
        {
            foreach (var usuario in Database.Funcionarios)
            {
                if (usuario.Login == username && usuario.Password == password)
                    return true;
            }

            return false;
        }
    }
}