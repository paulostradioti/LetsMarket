namespace LetsMarket
{
    public partial class Funcionario
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public EmployeeCategory Category { get; set; }

        public static void CadastrarFuncionarios()
        {
            var nome = ConsoleInput.GetString("Nome");
            var suggestion = CreateLoginSuggestionBasedOnName(nome);
            var login = ConsoleInput.GetString("Login", suggestion);
            var senha = ConsoleInput.GetPassword("Senha");
            var category = EmployeeCategory.Assistant;

            foreach (var categoria in Enum.GetNames<EmployeeCategory>())
            {
                var texto = $"O funcionário é {categoria}";
                var valor = ConsoleInput.GetBoolean(texto, BooleanType.YN);

                if (valor)
                {
                    category = Enum.Parse<EmployeeCategory>(categoria);
                    break;
                }
            }

            var empregado = new Funcionario
            {
                Nome = nome,
                Login = login,
                Password = senha,
                Category = category
            };

            Database.Funcionarios.Add(empregado);
            Database.Save();

            Console.WriteLine("Cadastrando Funcionários");
        }

        private static string CreateLoginSuggestionBasedOnName(string nome)
        {
            var parts = nome?.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            var suggestion = parts?.Length > 0 ? (parts.Length > 1 ? $"{parts[0]}.{parts[parts.Length - 1]}" : $"{parts[0]}" ) : "";

            return suggestion.ToLower();
        }

        public static void ListarFuncionarios()
        {
            Console.WriteLine("Listando Funcionários");
            Console.WriteLine();

            foreach (var funcionario in Database.Funcionarios)
                Console.WriteLine($"{funcionario.Nome} - {funcionario.Category} - {funcionario.Login}");
        }
    }
}