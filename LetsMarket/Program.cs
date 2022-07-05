using BetterConsoleTables;
using GetPass;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LetsMarket
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Let's Store";

            //FazLogin();

            var menu = new MenuItem("Menu Principal");

            var produtos = new MenuItem("Produtos");
            produtos.Add(new MenuItem("Cadastrar Produtos", Produtos.CadastrarProdutos));
            produtos.Add(new MenuItem("Listar Produtos", Produtos.ListarProdutos));

            var funcionarios = new MenuItem("Funcionários");
            funcionarios.Add(new MenuItem("Cadastrar Funcionários", Funcionario.CadastrarFuncionarios));
            funcionarios.Add(new MenuItem("Listar Funcionários", Funcionario.ListarFuncionarios));

            var submenu = new MenuItem("Submenu");
            submenu.Add(new MenuItem("item do submenu"));

            menu.Add(produtos);
            menu.Add(funcionarios);
            menu.Add(submenu);

            menu.Execute();
        }

        private static void FazLogin()
        {

            var title = "SYSTEM LOGIN";
            Console.WriteLine(title);
            
            Console.Write("login: ");
            var username = Console.ReadLine();
            var password = ConsolePasswordReader.Read("senha: ");

            if (!LoginIsValid(username, password))
            {
                Console.WriteLine("Dados Incorretos");

                Thread.Sleep(1000);
                Environment.Exit(0);
            }
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