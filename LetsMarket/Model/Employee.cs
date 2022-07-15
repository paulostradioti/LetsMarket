using BetterConsoleTables;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public class Employee : IPessoa
    {
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Categoria")]
        public EmployeeCategory Category { get; set; }

        public enum EmployeeCategory
        {
            [Display(Name = "Caixa")]
            Cashier,

            [Display(Name = "Gerente")]
            Manager,

            [Display(Name = "Assistente")]
            Assistant,
        }

        public static void Add()
        {
            var employee = Prompt.Bind<Employee>();
            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            InitializeDatabase.Add(employee);
            InitializeDatabase.Save(DatabaseOption.Employee);
        }
        public static void List()
        {
            Console.WriteLine("Listando Funcionários");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(InitializeDatabase.Employee);
            Console.WriteLine(table.ToString());
        }

        public override string ToString()
        {
            return Name;
        }

        public static void Edit()
        {
            var employee = Prompt.Select("Selecione o Funcionário para Editar", InitializeDatabase.Employee, defaultValue: InitializeDatabase.Employee[0]);

            Prompt.Bind(employee);

            InitializeDatabase.Save(DatabaseOption.Employee);
        }

        public static void Remove()
        {
            if (InitializeDatabase.Employee.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var employee = Prompt.Select("Selecione o Funcionário para Remover", InitializeDatabase.Employee);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            InitializeDatabase.Employee.Remove(employee);
            InitializeDatabase.Save(DatabaseOption.Employee);
        }
    }
}