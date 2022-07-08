using Bogus;
using Bogus.Extensions.Brazil;

namespace LetsMarket
{
    public static class ClienteFaker
    {
        public static Faker<Client> Gerar()
        {
            Faker<Client> cliente = new Faker<Client>("pt_BR")
                .RuleFor(s => s.Name, f => f.Person.FullName)
                .RuleFor(s => s.Document, f => f.Person.Cpf())
                .RuleFor(s => s.Category, f => f.PickRandom<Client.ClientCategory>());

            return cliente;
        }
    }
}
