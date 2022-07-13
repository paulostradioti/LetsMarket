using Sharprompt;
using LetsMarket.Controller;

namespace LetsMarket
{
    public class Program
    {     
        static void Main()
        {
            Design.SetupPrompt();
            Console.Title = "Let's Store";

            // Injeção de dependência?
            ILoginValidator loginValidator = new LoginValidator();
            ILoginErrorMessage loginError = new LoginErrorMessage();
            var login = new Login(loginValidator, loginError);
            login.AttemptToLogin();
            //------------------------

            MenuItem.CreateMenus();
        }
    }
}