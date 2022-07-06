using BetterConsoleTables;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public class Cliente
    {
        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "O Documento é Obrigatório")]
        [MinLength(11)]
        [MaxLength(11)]
        public string Documento { get; set; }


        [Display(Name = "Categoria")]
        public ClientCategory? Category { get; set; }

        public static void CadastrarClientes()
        {
            var empregado = Prompt.Bind<Cliente>();

            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            Database.Clientes.Add(empregado);
            Database.Save(DatabaseOption.Clients);
        }
        public static void ListarClientes()
        {
            Console.WriteLine("Listando Clientes");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Clientes);
            Console.WriteLine(table.ToString());
        }

        public override string ToString()
        {
            return $"{Nome} - {Documento}";
        }

        public static void EditarClientes()
        {
            var client = Prompt.Select("Selecione o Cliente para Editar", Database.Clientes, defaultValue: Database.Clientes[0]);

            Prompt.Bind(client);

            Database.Save(DatabaseOption.Clients);
        }

        public static void RemoverClientes()
        {
            if (Database.Clientes.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var client = Prompt.Select("Selecione o Cliente para Remover", Database.Clientes);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Database.Clientes.Remove(client);
            Database.Save(DatabaseOption.Clients);
        }
    }
}