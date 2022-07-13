namespace LetsMarket.Controller
{
    public interface IReceiptDesign
    {
        string ToString();

        int SetColumnWidth();
        
        void DesignTable(List<Sales> items);
    }
}
