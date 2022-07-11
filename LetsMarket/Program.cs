using LetsMarket.Business;
using LetsMarket.Infrastructure;
using Sharprompt;

namespace LetsMarket
{
    public class Program
    {     
        static void Main()
        {
            ConfigureApplication();
            AuthenticateUser();
            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            var menu = new MenuItem("Menu Principal");

            var produtos = new MenuItem("Produtos");
            produtos.Add(new MenuItem("Cadastrar Produtos", Product.RegisterNewProduct));
            produtos.Add(new MenuItem("Listar Produtos", Product.ListExistingProcuts));
            produtos.Add(new MenuItem("Editar Produtos", Product.EditExistingProduct));
            produtos.Add(new MenuItem("Remover Produtos", Product.RemoveExistingProduct));

            var funcionarios = new MenuItem("Funcionários");
            funcionarios.Add(new MenuItem("Cadastrar Funcionários", Employee.RegisterNewEmployee));
            funcionarios.Add(new MenuItem("Listar Funcionários", Employee.ListExistingEmployees));
            funcionarios.Add(new MenuItem("Editar Funcionários", Employee.EditExistingEmployee));
            funcionarios.Add(new MenuItem("Remover Funcionários", Employee.RemoveExistingEmployee));

            var clientes = new MenuItem("Clientes");
            clientes.Add(new MenuItem("Cadastrar Clientes", Client.RegisterNewClient));
            clientes.Add(new MenuItem("Listar Clientes", Client.ListExistingClients));
            clientes.Add(new MenuItem("Editar Clientes", Client.EditExistingClient));
            clientes.Add(new MenuItem("Remover Clientes", Client.RemoveExistingClient));

            var vendas = new MenuItem("Vendas");
            vendas.Add(new MenuItem("Efetuar Venda", Sale.EfetuarVenda));

            menu.Add(produtos);
            menu.Add(funcionarios);
            menu.Add(clientes);
            menu.Add(vendas);
            menu.Add(new MenuItem("Sair", () => Environment.Exit(0)));

            menu.Execute();
        }

        private static void ConfigureApplication()
        {
            Console.Title = "Let's Store";

            Prompt.ColorSchema.Answer = ConsoleColor.White;
            Prompt.ColorSchema.Select = ConsoleColor.White;

            Prompt.Symbols.Prompt = new Symbol("", "");
            Prompt.Symbols.Done = new Symbol("", "");
            Prompt.Symbols.Error = new Symbol("", "");
        }

        private static void AuthenticateUser()
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