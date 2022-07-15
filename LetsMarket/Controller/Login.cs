using LetsMarket.Controller;

namespace LetsMarket
{
    public class Login
    {
        private readonly ILoginValidator _loginValidator;
        private readonly ILoginErrorMessage _loginError;

        public Login(ILoginValidator loginValidator, ILoginErrorMessage loginError)
        {
            _loginValidator = loginValidator;
            _loginError = loginError;
        }

        public void AttemptToLogin()
        {
            var loggedIn = false;
            var attempts = 0;

            do
            {
                attempts++;
                Console.Clear();

                if (attempts > 1) _loginError.GetLoginErrorMessage();

                Console.WriteLine("LOGIN\n");

                var username = ConsoleInput.GetString("Usuário");
                var password = ConsoleInput.GetPassword("Senha");

                if (_loginValidator.TryLogin(username, password))
                {
                    loggedIn = true;
                    // O que fazer com a linha abaixo?
                    InitializeDatabase.Employee.Remove(new Employee { Name = "Admin", Login = "admin", Password = "admin" });
                }
            } while (!loggedIn);
        }
    }
}


