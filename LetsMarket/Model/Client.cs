using BetterConsoleTables;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket
{
    public class Client : IPessoa
    {
        [Display(Name = "Nome")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Documento")]
        [Required(ErrorMessage = "O Documento é Obrigatório")]
        [MinLength(11)]
        [MaxLength(11)]
        public string Document { get; set; }


        [Display(Name = "Categoria")]
        public ClientCategory? Category { get; set; }

        public enum ClientCategory
        {
            Bronze,
            Prata,
            Ouro,
        }

        public static void Add()
        {
            var employee = Prompt.Bind<Client>();

            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            Database.Clients.Add(employee);
            Database.Save(DatabaseOption.Clients);
        }

        public static void List()
        {
            Console.WriteLine("Listando Clientes");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Clients);
            Console.WriteLine(table.ToString());
        }

        public override string ToString()
        {
            return $"{Name} - {Document}";
        }

        public static void Edit()
        {
            var client = Prompt.Select("Selecione o Cliente para Editar", Database.Clients, defaultValue: Database.Clients[0]);

            Prompt.Bind(client);

            Database.Save(DatabaseOption.Clients);
        }

        public static void Remove()
        {
            if (Database.Clients.Count == 1)
            {
                ConsoleInput.WriteError("Não é possível remover todos os usuários.");
                Console.ReadKey();
                return;
            }

            var client = Prompt.Select("Selecione o Cliente para Remover", Database.Clients);
            var confirm = Prompt.Confirm("Tem Certeza?", false);

            if (!confirm)
                return;

            Database.Clients.Remove(client);
            Database.Save(DatabaseOption.Clients);
        }
    }
}