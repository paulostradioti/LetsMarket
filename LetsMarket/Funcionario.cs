using BetterConsoleTables;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public class Funcionario
    {
        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Login")]
        [Required]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Categoria")]
        public EmployeeCategory Category { get; set; }

        public static void CadastrarFuncionarios()
        {
            var empregado = Prompt.Bind<Funcionario>();
            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            Database.Funcionarios.Add(empregado);
            Database.Save(DatabaseOption.Funcionarios);
        }

        private static string CreateLoginSuggestionBasedOnName(string nome)
        {
            var parts = nome?.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var suggestion = parts?.Length > 0 ? (parts.Length > 1 ? $"{parts[0]}.{parts[parts.Length - 1]}" : $"{parts[0]}") : "";

            return suggestion.ToLower();
        }

        public static void ListarFuncionarios()
        {
            Console.WriteLine("Listando Funcionários");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Funcionarios);
            Console.WriteLine(table.ToString());
        }

        public override string ToString()
        {
            return Nome;
        }

        public static void EditarFuncionarios()
        {
            var employee = Prompt.Select("Selecione o Funcionário para Editar", Database.Funcionarios, defaultValue: Database.Funcionarios[0]);

            Prompt.Bind(employee);

            Database.Save(DatabaseOption.Funcionarios);
        }

        public static void RemoverFuncionarios()
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
    }
}