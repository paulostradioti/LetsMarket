using Bogus;
using CsvHelper;
using LetsMarket.Abstractions;
using LetsMarket.Business;
using System.Globalization;
using System.Xml.Serialization;

namespace LetsMarket.Infrastructure
{
    internal enum DatabaseOption { Funcionarios, Products, Clients }

    internal partial class XmlDatabaseContext<TEntity> : IDatabaseContext  where TEntity : IDbEntity
    {
        private static Dictionary<Type, IEntityTable> _tables = new();

        static XmlDatabaseContext()
        {
            _tables.Add(typeof(Employee), new EntityTable<Employee>());
            _tables.Add(typeof(Product), new EntityTable<Product>());
            _tables.Add(typeof(Client), new EntityTable<Client>());

            InitializeDatabase();
        }

        private IList<TEntity> GetTable()
        {
            _tables.TryGetValue(typeof(TEntity), out var list);
            var table = list as List<TEntity> ?? new List<TEntity>();

            return table;
        }

        public IEnumerable<TEntity> GetAll<TEntity>()
        { 
            return GetTable<TEntity>().AsEnumerable();
        }

        void Insert<TEntity>(TEntity entity)
        {
            GetTable<TEntity>().Add(entity);
        }

        void Delete(IDbEntity entity)
        {
        }

        void UpdateStudent(IDbEntity entity)
        {
        }

        public static void InitializeDatabase()
        {
            //if (!File.Exists(_employeesDb))
            //{
            //    Funcionarios.Add(new Employee { Name = "Admin", Login = "admin", Password = "admin" });
            //    Save(DatabaseOption.Funcionarios);
            //}

            //if (!File.Exists(_productsDb) && File.Exists("dados.csv"))
            //{
            //    var faker = new Bogus.DataSets.Commerce();

            //    using (var reader = new StreamReader("dados.csv"))
            //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            //    {
            //        csv.Context.RegisterClassMap<CsvReaderClassMap>();
            //        var products = csv.GetRecords<Product>().ToList();
            //        Produtos = products.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
            //        products.ForEach(x => x.Price = decimal.Parse(faker.Price()));

            //        Save(DatabaseOption.Products);
            //    }
            //}

            //if (!File.Exists(_clientsDb))
            //{
            //    for (int i = 0; i < 10; i++)
            //        Clientes.Add(ClienteFaker.Gerar());

            //    Save(DatabaseOption.Clients);
            //}

            //Load(DatabaseOption.Funcionarios);
            //Load(DatabaseOption.Products);
            //Load(DatabaseOption.Clients);
        }

        private static void Load(DatabaseOption options)
        {
            //if (options == DatabaseOption.Funcionarios)
            //{
            //    XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Employee>));
            //    using (TextReader reader = new StreamReader(_employeesDb))
            //    {
            //        var funcionarios = employeeSerializer.Deserialize(reader) as List<Employee>;
            //        Funcionarios = funcionarios ?? new List<Employee>();
            //    }
            //}

            //if (options == DatabaseOption.Products)
            //{
            //    XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Product>));
            //    using (TextReader reader = new StreamReader(_productsDb))
            //    {
            //        var funcionarios = employeeSerializer.Deserialize(reader) as List<Product>;
            //        Produtos = funcionarios ?? new List<Product>();
            //    }
            //}

            //if (options == DatabaseOption.Clients)
            //{
            //    XmlSerializer clientSerializer = new XmlSerializer(typeof(List<Client>));
            //    using (TextReader reader = new StreamReader(_clientsDb))
            //    {
            //        var funcionarios = clientSerializer.Deserialize(reader) as List<Client>;
            //        Clientes = funcionarios ?? new List<Client>();
            //    }
            //}
        }

        public static void Save(DatabaseOption options)
        {
            //Console.WriteLine("Salvando...");

            //if (options == DatabaseOption.Funcionarios)
            //{
            //    XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Employee>));
            //    using (TextWriter writer = new StreamWriter(_employeesDb))
            //    {
            //        employeeSerializer.Serialize(writer, Funcionarios);
            //    }
            //}

            //if (options == DatabaseOption.Products)
            //{
            //    XmlSerializer productSerializer = new XmlSerializer(typeof(List<Product>));
            //    using (TextWriter writer = new StreamWriter(_productsDb))
            //    {
            //        productSerializer.Serialize(writer, Produtos);
            //    }
            //}

            //if (options == DatabaseOption.Clients)
            //{
            //    XmlSerializer clientSerializer = new XmlSerializer(typeof(List<Client>));
            //    using (TextWriter writer = new StreamWriter(_clientsDb))
            //    {
            //        clientSerializer.Serialize(writer, Clientes);
            //    }
            //}
            //Console.WriteLine("Salvo.");
        }
    }
}
