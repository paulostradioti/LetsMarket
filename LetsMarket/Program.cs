namespace LetsMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var opcoes = new string[] { "Login do Caixa", "Cadastrar Produto", "Consultar Produto", "Editar Produto", "Remover Produto", "Sair" };
            ExibeMenu(opcoes);
        }

        private static void ExibeMenu(string[] opcoes)
        {
            ConsoleKeyInfo entrada = new ConsoleKeyInfo();
            var selecionado = 0;
            do
            {
                ClearConsole();
                for (int i = 0; i < opcoes.Length; i++)
                {
                    SetConsoleColor(selecionado == i);

                    var item = opcoes[i];
                    Console.WriteLine($"« {item} »");
                }

                entrada = Console.ReadKey();
                if (entrada.Key == ConsoleKey.Enter)
                    ExecutaComandoSelecionado(selecionado);
                else
                    AtualizaSelecionado(entrada.Key);

            } while (entrada.Key != ConsoleKey.Escape);

            void AtualizaSelecionado(ConsoleKey key)
            {
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selecionado--;
                        if (selecionado < 0) selecionado = 0;
                        break;

                    case ConsoleKey.DownArrow:
                        selecionado++;
                        if (selecionado >= opcoes.Length) selecionado = opcoes.Length - 1;
                        break;

                    default:
                        break;
                }
            }
        }

        private static void ClearConsole()
        {
            Console.ResetColor();
            Console.Clear();
        }

        private static void SetConsoleColor(bool destaque)
        {
            if (destaque)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
                Console.ResetColor();
        }

        private static void ExecutaComandoSelecionado(int selecionado)
        {
            switch (selecionado)
            {
                case 0:
                    Console.WriteLine("Selecionada a opção 0");
                    break;

                case 1:
                    Console.WriteLine("Selecionada a opção 1");
                    break;

                case 2:
                    Console.WriteLine("Selecionada a opção 2");
                    break;

                case 3:
                    Console.WriteLine("Selecionada a opção 3");
                    break;

                case 4:
                    Console.WriteLine("Selecionada a opção 4");
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }

            Console.ReadLine();
        }
    }
}