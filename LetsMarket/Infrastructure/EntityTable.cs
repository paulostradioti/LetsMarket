using LetsMarket.Abstractions;
using LetsMarket.Business;

namespace LetsMarket.Infrastructure
{
    internal class EntityTable<T> : List<T>, IEntityTable where T : IDbEntity
    {

    }
}
