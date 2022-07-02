using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LetsMarket.Menu4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            Console.Title = "Let's Store";

            var menu = new MenuItem("Menu Principal");

            var produtos = new MenuItem("Produtos");
            produtos.Add(new MenuItem("Cadastrar Produtos", Produtos.CadastrarProdutos));
            produtos.Add(new MenuItem("Listar Produtos", Produtos.ListarProdutos));

            var funcionarios = new MenuItem("Funcionários");
            funcionarios.Add(new MenuItem("Cadastrar Funcionários", Funcionarios.CadastrarFuncionarios));
            funcionarios.Add(new MenuItem("Listar Funcionários", Funcionarios.ListarFuncionarios));

            var submenu = new MenuItem("Submenu");
            submenu.Add(new MenuItem("item do submenu"));

            menu.Add(produtos);
            menu.Add(funcionarios);
            menu.Add(submenu);

            menu.Execute();
        }
    }
}