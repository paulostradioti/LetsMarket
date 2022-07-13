using BetterConsoleTables;
using Sharprompt;

namespace LetsMarket
{
    public class Vendas
    {
        private static int _maiorColuna;
        private string _descricao;
        public static void SetTamanho(int tamanho) => _maiorColuna = tamanho;
        public string Codigo { get; set; }
        public string Descricao
        {
            get => _descricao;
            set
            {
                _descricao = value.PadRight(_maiorColuna + 5);
            }
        }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Subtotal { get => Quantidade * PrecoUnitario; }

        public override string ToString()
        {
            return Descricao;
        }

        public static void EfetuarVenda()
        {
            var max = Database.Products.Max(x => x.Description.Length);
            SetTamanho(max);

            var itensVenda = new List<Vendas>();

            var produtos = Database.Products.ToList();
            var sair = new Product { Code = "-1", Description = "Sair", Price = 0 }; //tem como melhorar?
            var fecharVenda = new Product { Code = "-1", Description = "Fechar Venda", Price = 0 };
            var cancelarItem = new Product { Code = "-1", Description = "Cancelar Item", Price = 0 };

            produtos.Add(cancelarItem);
            produtos.Add(fecharVenda);
            produtos.Add(sair);

            var total = decimal.Zero;
            Product produto = null;
            do
            {
                Console.Clear();
                Console.WriteLine("EFETUANDO UMA VENDA");

                var relatorio = new Table(TableConfiguration.UnicodeAlt());
                var maiorColuna = Database.Products.Max(x => x.Description);

                if (itensVenda.Count > 0)
                {
                    relatorio.From(itensVenda);
                    Console.WriteLine(relatorio.ToString());
                }

                Console.WriteLine();
                Console.WriteLine();

                // Early Return
                produto = Prompt.Select("Selecione o produto", produtos);

                if (produto == sair || produto == fecharVenda)
                {
                    break;
                }

                if (produto == cancelarItem)
                {
                    Console.Clear();
                    Console.WriteLine("Selecione o item a ser cancelado");
                    var item = Prompt.Select("Selecione o item a ser cancelado", itensVenda);
                    itensVenda.Remove(item);

                    total -= item.PrecoUnitario;
                }

                else 
                {
                    var quantidade = Prompt.Input<int>("Informe a quantidade", defaultValue: 1);
                    var item = new Vendas
                    {
                        Codigo = produto.Code,
                        Descricao = produto.Description,
                        PrecoUnitario = produto.Price,
                        Quantidade = quantidade
                    };
                    itensVenda.Add(item);
                    total += item.Subtotal;
                }
               
            } while (true);

            if (produto == fecharVenda)
            {
                var cor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"TOTAL DA COMPRA: {total}");
                Console.ForegroundColor = cor;
                Console.ReadKey();
            }

            produtos.Remove(sair);
            produtos.Remove(fecharVenda);
            produtos.Remove(cancelarItem);

            return;
        }
    }
}