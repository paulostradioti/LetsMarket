using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket
{
    internal static class Menu
    {
        //aqui vale trazer as informações que estão no comecinho do Program.
        //Tem muita coisa lá que é só chamando menu do produto, menu do cliente, menu do funcionário
        //(e tentar otimizar para um único menu se possível)



        public static void CreateSubMenus()
        {
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

    }
}
