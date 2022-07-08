using Sharprompt;

namespace LetsMarket
{
    public class Program
    {     
        static void Main()
        {
            Design.SetupPrompt();
            Console.Title = "Let's Store";

            //VerificaLogin();

            MenuItem.CreateMenus();
        }

        
    }
}