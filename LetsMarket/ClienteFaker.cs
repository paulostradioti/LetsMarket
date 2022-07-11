using Bogus;
using Bogus.Extensions.Brazil;

namespace LetsMarket
{
    public static class ClienteFaker
    {
        public static Faker<Cliente> Gerar()
        {
            Faker<Cliente> cliente = new Faker<Cliente>("pt_BR")
                .RuleFor(s => s.Nome, f => f.Person.FullName)
                .RuleFor(s => s.Documento, f => f.Person.Cpf())
                .RuleFor(s => s.Category, f => f.PickRandom<ClientCategory>());

            return cliente;
        }
    }
}
