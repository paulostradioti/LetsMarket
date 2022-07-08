using BetterConsoleTables;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public class Employee
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

        public static void ListEmployee()
        {
            Console.WriteLine("Listando Funcionários");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Employee);
            Console.WriteLine(table.ToString());
        }

        public override string ToString()
        {
            return Name;
        }

        public static void EditEmployee()
        {
            var employee = Prompt.Select("Selecione o Funcionário para Editar", Database.Employee, defaultValue: Database.Employee[0]);

            Prompt.Bind(employee);

            Database.Save(DatabaseOption.Employee);
        }

        public static void RemoveEmployee()
        {
            if (Database.Employee.Count == 1)
            {
                ConsoleInputLogin.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var employee = Prompt.Select("Selecione o Funcionário para Remover", Database.Employee);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Database.Employee.Remove(employee);
            Database.Save(DatabaseOption.Employee);
        }
    }
}