using Bogus;
using CsvHelper;
using System.Globalization;
using System.Xml.Serialization;

namespace LetsMarket
{
    public enum DatabaseOption { Funcionarios, Products, Clients }

    public class Database
    {
        private static readonly string _rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _employeesDb = Path.Combine(_rootDirectory, "employees.xml");
        private static readonly string _productsDb = Path.Combine(_rootDirectory, "products.xml");
        private static readonly string _clientsDb = Path.Combine(_rootDirectory, "clients.xml");

        public static List<Funcionario> Funcionarios = new List<Funcionario>();
        public static List<Produto> Produtos = new List<Produto>();
        public static List<Cliente> Clientes = new List<Cliente>();

        static Database()
        {
            InitializeDatabase();
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists(_employeesDb))
            {
                Funcionarios.Add(new Funcionario { Nome = "Admin", Login = "admin", Password = "admin" });
                Save(DatabaseOption.Funcionarios);
            }

            if (!File.Exists(_productsDb) && File.Exists("dados.csv"))
            {
                var faker = new Bogus.DataSets.Commerce();

                using (var reader = new StreamReader("dados.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CsvReaderClassMap>();
                    var products = csv.GetRecords<Produto>().ToList();
                    Produtos = products.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
                    products.ForEach(x => x.Price = decimal.Parse(faker.Price()));

                    Save(DatabaseOption.Products);
                }
            }

            if (!File.Exists(_clientsDb))
            {
                for (int i = 0; i < 10; i++)
                    Clientes.Add(ClienteFaker.Gerar());
                
                Save(DatabaseOption.Clients);
            }

            Load(DatabaseOption.Funcionarios);
            Load(DatabaseOption.Products);
            Load(DatabaseOption.Clients);
        }

        private static void Load(DatabaseOption options)
        {
            if (options == DatabaseOption.Funcionarios)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Funcionario>));
                using (TextReader reader = new StreamReader(_employeesDb))
                {
                    var funcionarios = employeeSerializer.Deserialize(reader) as List<Funcionario>;
                    Funcionarios = funcionarios ?? new List<Funcionario>();
                }
            }

            if (options == DatabaseOption.Products)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Produto>));
                using (TextReader reader = new StreamReader(_productsDb))
                {
                    var funcionarios = employeeSerializer.Deserialize(reader) as List<Produto>;
                    Produtos = funcionarios ?? new List<Produto>();
                }
            }

            if (options == DatabaseOption.Clients)
            {
                XmlSerializer clientSerializer = new XmlSerializer(typeof(List<Cliente>));
                using (TextReader reader = new StreamReader(_clientsDb))
                {
                    var funcionarios = clientSerializer.Deserialize(reader) as List<Cliente>;
                    Clientes = funcionarios ?? new List<Cliente>();
                }
            }
        }

        public static void Save(DatabaseOption options)
        {
            Console.WriteLine("Salvando...");

            if (options == DatabaseOption.Funcionarios)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Funcionario>));
                using (TextWriter writer = new StreamWriter(_employeesDb))
                {
                    employeeSerializer.Serialize(writer, Funcionarios);
                }
            }

            if (options == DatabaseOption.Products)
            {
                XmlSerializer productSerializer = new XmlSerializer(typeof(List<Produto>));
                using (TextWriter writer = new StreamWriter(_productsDb))
                {
                    productSerializer.Serialize(writer, Produtos);
                }
            }

            if (options == DatabaseOption.Clients)
            {
                XmlSerializer clientSerializer = new XmlSerializer(typeof(List<Cliente>));
                using (TextWriter writer = new StreamWriter(_clientsDb))
                {
                    clientSerializer.Serialize(writer, Clientes);
                }
            }
            Console.WriteLine("Salvo.");
        }
    }
}
