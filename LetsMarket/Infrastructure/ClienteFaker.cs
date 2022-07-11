using Bogus;
using Bogus.Extensions.Brazil;
using LetsMarket.Business;
using LetsMarket.Constants;

namespace LetsMarket.Infrastructure
{
    public static class ClienteFaker
    {
        public static Faker<Client> Gerar()
        {
            Faker<Client> cliente = new Faker<Client>("pt_BR")
                .RuleFor(s => s.Name, f => f.Person.FullName)
                .RuleFor(s => s.Document, f => f.Person.Cpf())
                .RuleFor(s => s.Category, f => f.PickRandom<ClientCategory>());

            return cliente;
        }
    }
}
