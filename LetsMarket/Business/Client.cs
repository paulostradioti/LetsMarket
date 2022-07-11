using BetterConsoleTables;
using LetsMarket.Constants;
using LetsMarket.Infrastructure;
using Sharprompt;
using System.ComponentModel.DataAnnotations;

namespace LetsMarket.Business
{
    internal class Client
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é Obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Documento")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "O documento deve ter 11 dígitos numéricos (CPF). Não use pontuação.")]
        public string Document { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "A Categoria é obrigatória.")]
        public ClientCategory? Category { get; set; }

        public static void RegisterNewClient()
        {
            var empregado = Prompt.Bind<Client>();

            var save = Prompt.Confirm("Deseja Salvar?");
            if (!save)
                return;

            Database.Clientes.Add(empregado);
            Database.Save(DatabaseOption.Clients);
        }

        public static void ListExistingClients()
        {
            Console.WriteLine("Listando Clientes");
            Console.WriteLine();

            var table = new Table(TableConfiguration.UnicodeAlt());
            table.From(Database.Clientes);
            Console.WriteLine(table.ToString());
        }

        public static void EditExistingClient()
        {
            var client = Prompt.Select("Selecione o Cliente para Editar", Database.Clientes, defaultValue: Database.Clientes[0]);
            Prompt.Bind(client);
            Database.Save(DatabaseOption.Clients);
        }

        public static void RemoveExistingClient()
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

        public override string ToString()
        {
            return $"{Name} - {Document}";
        }
    }
}