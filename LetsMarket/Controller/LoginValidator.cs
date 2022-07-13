using LetsMarket.Controller;

namespace LetsMarket
{
    public class LoginValidator : ILoginValidator
    {
        public bool TryLogin(string? username, string password)
        {
            foreach (var user in Database.Employee)
            {
                if (user.Login.ToLower() == username.ToLower() && user.Password == password)
                    return true;
            }

            return false;
        }
    }
}

