using BetterConsoleTables;

namespace LetsMarket.Controller
{
    public class ReceiptDesign : IReceiptDesign
    {
        private int _columnWidth;

        public int SetColumnWidth()
        {
            _columnWidth = InitializeDatabase.Products.Max(x => x.Description.Length);
            return _columnWidth;
        }

        public void DesignTable(List<Sales> items)
        {
            var receiptFormat = new Table(TableConfiguration.UnicodeAlt());

            if (items.Count > 0)
            {
                receiptFormat.From(items);
                Console.WriteLine(receiptFormat.ToString());
            }
        }
    }
}
