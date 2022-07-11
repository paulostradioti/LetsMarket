using LetsMarket.Abstractions;
using LetsMarket.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMarket.Infrastructure.Repository
{
    internal class ClientRepository : IClientRepository
    {
        public ClientRepository(IDatabaseContext databaseContext)
        {

        }

        public void DeleteClient(Client client)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public void InsertClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
