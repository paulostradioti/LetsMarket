namespace LetsMarket.Constants
{
    internal static class DbPaths
    {
        private static readonly string _rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string Employees { get; } = Path.Combine(_rootDirectory, "employees.xml");
        public static string Products { get; } = Path.Combine(_rootDirectory, "products.xml");
        public static string Clients { get; } = Path.Combine(_rootDirectory, "clients.xml");
    }
}
