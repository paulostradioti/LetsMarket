using BetterConsoleTables;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public class Product
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

        public static void AddProduct()
        {
            var product = Prompt.Bind<Product>();

            if (!Prompt.Confirm("Deseja Salvar?"))
                return;

            InitializeDatabase.Products.Add(product);
            InitializeDatabase.Save(DatabaseOption.Products);
        }

        public static void ListProduct()
        {
            Console.WriteLine("Listando Produtos");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(InitializeDatabase.Products);
            Console.WriteLine(table.ToString());
        }

        public override string ToString()
        {
            return Description;
        }

        public static void EditProduct()
        {
            var produto = Prompt.Select("Selecione o Produto para Editar", InitializeDatabase.Products, defaultValue: InitializeDatabase.Products[0]);

            Prompt.Bind(produto);

            InitializeDatabase.Save(DatabaseOption.Products);
        }

        public static void RemoveProduct()
        {
            var product = Prompt.Select("Selecione o Produto para Remover", InitializeDatabase.Products);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            InitializeDatabase.Products.Remove(product);
            InitializeDatabase.Save(DatabaseOption.Products);
        }
    }
}