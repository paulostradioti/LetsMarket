using Bogus;
using CsvHelper;
using System.Globalization;
using System.Xml.Serialization;

namespace LetsMarket
{
    public enum DatabaseOption { Employee, Products, Clients }

    public class InitializeDatabase
    {
        public static readonly string _rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string _employeesDb = Path.Combine(_rootDirectory, "employees.xml");
        public static readonly string _productsDb = Path.Combine(_rootDirectory, "products.xml");
        public static readonly string _clientsDb = Path.Combine(_rootDirectory, "clients.xml");

        public static List<Employee> Employee = new List<Employee>();
        public static List<Product> Products = new List<Product>();
        public static List<Client> Clients = new List<Client>();

        static InitializeDatabase()
        {
            CreateDatabase();
        }

        public static void Add(Employee input)
        {
            Employee.Add(input);
            //Como diferenciar os tipos dentro dessa lista
        }

        public static void CreateDatabase()
        {
            if (!File.Exists(_employeesDb))
            {
                Employee.Add(new Employee { Name = "Admin", Login = "admin", Password = "admin" });
                DatabaseHandler.Save(DatabaseOption.Employee);
            }

            if (!File.Exists(_productsDb) && File.Exists("dados.csv"))
            {
                var faker = new Bogus.DataSets.Commerce();

                using (var reader = new StreamReader("dados.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvReaderClassMap>();
                    var products = csv.GetRecords<Product>().ToList();
                    Products = products.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
                    products.ForEach(x => x.Price = decimal.Parse(faker.Price()));

                    DatabaseHandler.Save(DatabaseOption.Products);
                }
            }
        

            if (!File.Exists(_clientsDb))
            {
                for (int i = 0; i < 10; i++)
                    Clients.Add(ClienteFaker.Gerar());

                DatabaseHandler.Save(DatabaseOption.Clients);
            }

            DatabaseHandler.Load(DatabaseOption.Employee);
            DatabaseHandler.Load(DatabaseOption.Products);
            DatabaseHandler.Load(DatabaseOption.Clients);
            
        }

        

        
    }
}
