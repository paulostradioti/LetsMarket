using BetterConsoleTables;
using LetsMarket.Constants;
using LetsMarket.Infrastructure;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Business
{
    internal class Employee
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "A categoria é obrigatória")]
        public EmployeeCategory Category { get; set; }

        public static void RegisterNewEmployee()
        {
            var empregado = Prompt.Bind<Employee>();
            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            Database.Funcionarios.Add(empregado);
            Database.Save(DatabaseOption.Funcionarios);
        }

        public static void ListExistingEmployees()
        {
            Console.WriteLine("Listando Funcionários");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Funcionarios);
            Console.WriteLine(table.ToString());
        }

        public static void EditExistingEmployee()
        {
            var employee = Prompt.Select("Selecione o Funcionário para Editar", Database.Funcionarios, defaultValue: Database.Funcionarios[0]);

            Prompt.Bind(employee);

            Database.Save(DatabaseOption.Funcionarios);
        }

        public static void RemoveExistingEmployee()
        {
            if (Database.Funcionarios.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var employee = Prompt.Select("Selecione o Funcionário para Remover", Database.Funcionarios);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Database.Funcionarios.Remove(employee);
            Database.Save(DatabaseOption.Funcionarios);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}