using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using CsvHelper;
using System.Globalization;
using System.Xml.Serialization;

namespace LetsMarket
{
    public static class DatabaseHandler
    {
        
        public static void Load(DatabaseOption options)
        {
            if (options == DatabaseOption.Employee)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Employee>));
                using (TextReader reader = new StreamReader(InitializeDatabase._employeesDb))
                {
                    var employee = employeeSerializer.Deserialize(reader) as List<Employee>;
                    InitializeDatabase.Employee = employee ?? new List<Employee>();
                }
            }

            if (options == DatabaseOption.Products)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Product>));
                using (TextReader reader = new StreamReader(InitializeDatabase._productsDb))
                {
                    var funcionarios = employeeSerializer.Deserialize(reader) as List<Product>;
                    InitializeDatabase.Products = funcionarios ?? new List<Product>();
                }
            }

            if (options == DatabaseOption.Clients)
            {
                XmlSerializer clientSerializer = new XmlSerializer(typeof(List<Client>));
                using (TextReader reader = new StreamReader(InitializeDatabase._clientsDb))
                {
                    var client = clientSerializer.Deserialize(reader) as List<Client>;
                    InitializeDatabase.Clients = client ?? new List<Client>();
                }
            }
        }

        public static void Save(DatabaseOption options)
        {
            Console.WriteLine("Salvando...");

            if (options == DatabaseOption.Employee)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Employee>));
                using (TextWriter writer = new StreamWriter(InitializeDatabase._employeesDb))
                {
                    employeeSerializer.Serialize(writer, InitializeDatabase.Employee);
                }
            }

            if (options == DatabaseOption.Products)
            {
                XmlSerializer productSerializer = new XmlSerializer(typeof(List<Product>));
                using (TextWriter writer = new StreamWriter(InitializeDatabase._productsDb))
                {
                    productSerializer.Serialize(writer, InitializeDatabase.Products);
                }
            }

            if (options == DatabaseOption.Clients)
            {
                XmlSerializer clientSerializer = new XmlSerializer(typeof(List<Client>));
                using (TextWriter writer = new StreamWriter(InitializeDatabase._clientsDb))
                {
                    clientSerializer.Serialize(writer, InitializeDatabase.Clients);
                }
            }
            Console.WriteLine("Salvo.");
        }
    }
}
