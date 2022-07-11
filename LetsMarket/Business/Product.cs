using BetterConsoleTables;
using LetsMarket.Infrastructure;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Business
{
    internal class Product : IDbEntity
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "O código é obrigatório")]
        public string Code { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Description { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        public decimal Price { get; set; }

        public static void RegisterNewProduct()
        {
            var product = Prompt.Bind<Product>();

            if (!Prompt.Confirm("Deseja Salvar?"))
                return;

            Database.Produtos.Add(product);
            Database.Save(DatabaseOption.Products);
        }

        public static void ListExistingProcuts()
        {
            Console.WriteLine("Listando Produtos");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Produtos);
            Console.WriteLine(table.ToString());
        }

        public static void EditExistingProduct()
        {
            var produto = Prompt.Select("Selecione o Produto para Editar", Database.Produtos, defaultValue: Database.Produtos[0]);

            Prompt.Bind(produto);

            Database.Save(DatabaseOption.Products);
        }

        public static void RemoveExistingProduct()
        {
            var produto = Prompt.Select("Selecione o Produto para Remover", Database.Produtos);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Database.Produtos.Remove(produto);
            Database.Save(DatabaseOption.Products);
        }

        public override string ToString()
        {
            return Description;
        }
    }
}