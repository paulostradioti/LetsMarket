using Sharprompt;

namespace LetsMarket
{
    public class Program
    {     
        static void Main()
        {
            ConfiguraPrompt();
            Console.Title = "Let's Store";

            VerificaLogin();

            var menu = new MenuItem("Menu Principal");

            var produtos = new MenuItem("Produtos");
            produtos.Add(new MenuItem("Cadastrar Produtos", Produto.CadastrarProdutos));
            produtos.Add(new MenuItem("Listar Produtos", Produto.ListarProdutos));
            produtos.Add(new MenuItem("Editar Produtos", Produto.EditarProduto));
            produtos.Add(new MenuItem("Remover Produtos", Produto.RemoverProduto));

            var funcionarios = new MenuItem("Funcionários");
            funcionarios.Add(new MenuItem("Cadastrar Funcionários", Funcionario.CadastrarFuncionarios));
            funcionarios.Add(new MenuItem("Listar Funcionários", Funcionario.ListarFuncionarios));
            funcionarios.Add(new MenuItem("Editar Funcionários", Funcionario.EditarFuncionarios));
            funcionarios.Add(new MenuItem("Remover Funcionários", Funcionario.RemoverFuncionarios));

            var clientes = new MenuItem("Clientes");
            clientes.Add(new MenuItem("Cadastrar Clientes", Cliente.CadastrarClientes));
            clientes.Add(new MenuItem("Listar Clientes", Cliente.ListarClientes));
            clientes.Add(new MenuItem("Editar Clientes", Cliente.EditarClientes));
            clientes.Add(new MenuItem("Remover Clientes", Cliente.RemoverClientes));

            var vendas = new MenuItem("Vendas");
            vendas.Add(new MenuItem("Efetuar Venda", Vendas.EfetuarVenda));

            menu.Add(produtos);
            menu.Add(funcionarios);
            menu.Add(clientes);
            menu.Add(vendas);
            menu.Add(new MenuItem("Sair", () => Environment.Exit(0)));

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