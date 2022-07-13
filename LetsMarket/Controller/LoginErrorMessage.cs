using LetsMarket.Controller;

namespace LetsMarket
{
    public class LoginErrorMessage : ILoginErrorMessage
    {
        public void GetLoginErrorMessage()
        {
            Console.WriteLine("Usuário e/ou palavra-chave incorreta.");
        }
    }
}
