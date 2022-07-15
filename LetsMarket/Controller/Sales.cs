using Sharprompt;
using LetsMarket.Controller;

namespace LetsMarket
{
    public class Sales
    {
        IReceiptDesign _receiptDesign;

        public Sales(IReceiptDesign receiptDesign)
        {
            _receiptDesign = receiptDesign;
        }

        private string? Code { get; set; }
        private string? Description { get; set; }
        private int Amount { get; set; }
        private decimal PricePerUnit { get; set; }
        private decimal Subtotal { get => Amount * PricePerUnit; }

        public override string ToString() => Description;

        public void SellItems()
        {
            var items = new List<Sales>();

            var columnWidth = _receiptDesign.SetColumnWidth();

            //Esta linha (abaixo)           
            var products = InitializeDatabase.Products.ToList();

            //Refatorar aqui
            var exit = new Product { Code = "-1", Description = "Sair", Price = 0 };
            var closeSale = new Product { Code = "-1", Description = "Finalizar venda", Price = 0 };
            var cancelItem = new Product { Code = "-1", Description = "Cancelar item", Price = 0 };

            products.Add(cancelItem);
            products.Add(closeSale);
            products.Add(exit);
            //-------------

            var total = decimal.Zero;
            Product product = null;
            do
            {
                Console.Clear();
                Console.WriteLine("EFETUANDO UMA VENDA");

                _receiptDesign.DesignTable(items);

                Console.WriteLine("\n\n");

                product = Prompt.Select("Selecione o produto", products);

                if (product == exit || product == closeSale) break;

                if (product == cancelItem)
                {
                    Console.Clear();
                    var item = Prompt.Select("Selecione o item a ser cancelado", items);
                    items.Remove(item);

                    total -= item.PricePerUnit;
                }

                else
                {
                    var quantidade = Prompt.Input<int>("Informe a quantidade", defaultValue: 1);
                    var item = new Sales(_receiptDesign)
                    {
                        Code = product.Code,
                        Description = product.Description.PadRight(columnWidth + 5, ' '),
                        PricePerUnit = product.Price,
                        Amount = quantidade
                    };
                    items.Add(item);
                    total += item.Subtotal;
                }

            } while (true);

            if (product == closeSale)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine($"TOTAL DA COMPRA: {total:N2}.");
                Console.ReadKey();
            }

            //Refatorar aqui
            products.Remove(cancelItem!);
            products.Remove(closeSale!);
            products.Remove(exit!);
            //--------------
        }
    }
}