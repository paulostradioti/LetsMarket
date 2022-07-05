using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LetsMarket
{
    [Flags]
    public enum DatabaseOption { All, Funcionarios }
    public class Database
    {
        private static readonly string _rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string _employeesDb = Path.Combine(_rootDirectory, "employees.xml");

        public static List<Funcionario> Funcionarios = new List<Funcionario>();

        static Database()
        {
            InitializeDatabase();
        }

        private static void InitializeDatabase()
        {
            if (File.Exists(_employeesDb))
            {
                Load(DatabaseOption.Funcionarios);
                return;
            }

            Funcionarios.Add(new Funcionario { Nome = "Admin", Login = "admin", Password = "admin" });
            Save(DatabaseOption.Funcionarios);
        }

        private static void Load(DatabaseOption options)
        {
            var all = options.HasFlag(DatabaseOption.All);
            var employees = options.HasFlag(DatabaseOption.Funcionarios);

            if (employees || all)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Funcionario>));
                using (TextReader reader = new StreamReader(_employeesDb))
                {
                    var funcionarios = employeeSerializer.Deserialize(reader) as List<Funcionario>;
                    Funcionarios = funcionarios ?? new List<Funcionario>();
                }
            }
        }

        public static void Save(DatabaseOption options = DatabaseOption.All)
        {
            var all = options.HasFlag(DatabaseOption.All);
            var employees = options.HasFlag(DatabaseOption.Funcionarios);

            if (employees || all)
            {
                XmlSerializer employeeSerializer = new XmlSerializer(typeof(List<Funcionario>));
                using (TextWriter writer = new StreamWriter(_employeesDb))
                {
                    employeeSerializer.Serialize(writer, Funcionarios);
                }
            }
        }
    }
}
