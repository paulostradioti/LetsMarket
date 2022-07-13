namespace LetsMarket.Controller
{
    public interface ILoginValidator
    {
        bool TryLogin(string? username, string password);
    }
}
