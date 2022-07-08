using Sharprompt;

namespace LetsMarket
{
    public class Program
    {     
        static void Main()
        {
            ConfiguraPrompt();
            Console.Title = "Let's Store";

            ValidaçãoAcesso.VerificaLogin();

            var menu = new MenuItem("Menu Principal");

            var produtos = new MenuItem("Produtos");
            produtos.Add(new MenuItem("Cadastrar Produtos", BaseInicial.CadastrarProdutos));
            produtos.Add(new MenuItem("Listar Produtos", Produto.ListarProdutos));
            produtos.Add(new MenuItem("Editar Produtos", Produto.EditarProduto));
            produtos.Add(new MenuItem("Remover Produtos", Produto.RemoverProduto));

            var funcionarios = new MenuItem("Funcionários");
            funcionarios.Add(new MenuItem("Cadastrar Funcionários", BaseInicial.CadastrarFuncionarios));
            funcionarios.Add(new MenuItem("Listar Funcionários", Funcionario.ListarFuncionarios));
            funcionarios.Add(new MenuItem("Editar Funcionários", Funcionario.EditarFuncionarios));
            funcionarios.Add(new MenuItem("Remover Funcionários", Funcionario.RemoverFuncionarios));

            var clientes = new MenuItem("Clientes");
            clientes.Add(new MenuItem("Cadastrar Clientes", BaseInicial.CadastrarClientes));
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

        
    }
}