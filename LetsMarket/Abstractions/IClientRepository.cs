using LetsMarket.Business;

namespace LetsMarket.Abstractions
{
    internal interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        void InsertClient(Client client);
        void DeleteClient(Client client);
        void UpdateStudent(Client client);
    }
}
