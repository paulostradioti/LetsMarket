using LetsMarket.Controller;

namespace LetsMarket
{

    public class MenuItem
    {
        private const string UNSELECTED = "|     ";
        private const string SELECTED = "|   » ";
        private readonly int LINE_WIDTH = Console.WindowWidth / 3;//50;

        public MenuType Type { get; }
        private static MenuItem _root;
        private MenuItem parent = null;
        private string title;
        private List<MenuItem> items;
        private Action action;

        private int selectedIndex = 0;
        public MenuItem(string title)
        {
            this.title = title;
            items = new List<MenuItem>();
            if (_root == null) _root = this;
            Type = MenuType.Submenu;
        }

        public MenuItem(string title, Action action) : this(title)
        {
            this.action = action;
            Type = MenuType.Command;
        }

        public void Add(MenuItem menuItem)
        {
            menuItem.parent = this;
            items.Add(menuItem);
        }

        public void Execute()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.ResetColor();

            switch (Type)
            {
                case MenuType.Submenu:
                    if (items.Count == 0)
                        return;
                    RenderSubmenu();
                    break;

                case MenuType.Command:
                    action();
                    Console.ReadKey(true);
                    break;

                default:
                    break;
            }

            return;

            void RenderSubmenu()
            {
                var key = new ConsoleKeyInfo();
                do
                {
                    Console.ResetColor();
                    Console.Clear();

                    var menuTitle = $"{UNSELECTED}{title.ToUpperInvariant().PadRight(LINE_WIDTH)}|";
                    var lineSeparator = $"|{new string('-', menuTitle.Length - 2)}|";

                    Console.WriteLine(lineSeparator);
                    Console.WriteLine(menuTitle);
                    Console.WriteLine(lineSeparator);

                    for (int i = 0; i < items.Count; i++)
                    {
                        var isSelected = i == selectedIndex;
                        var margin = isSelected ? SELECTED : UNSELECTED;

                        if (isSelected)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine($"{margin}{items[i].ToString().PadRight(LINE_WIDTH)}|");
                        Console.ResetColor();
                    }
                    Console.WriteLine(lineSeparator);

                    key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.PageUp:
                        case ConsoleKey.UpArrow:
                            selectedIndex = Math.Max(selectedIndex - 1, 0);
                            break;
                        case ConsoleKey.PageDown:
                        case ConsoleKey.DownArrow:
                            selectedIndex = Math.Min(selectedIndex + 1, Math.Max(items.Count - 1, 0));
                            break;
                        case ConsoleKey.Enter:
                        case ConsoleKey.RightArrow:
                            items[selectedIndex].Execute();
                            break;
                        case ConsoleKey.Escape:
                            if (this != _root)
                                return;
                            break;
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.Backspace:
                            if (this != _root)
                                return;
                            break;
                        default:
                            break;
                    }
                } while (true);
            }
        }


        public override string ToString()
        {
            return title;
        }
        public static void CreateMenus()
        {
            var menu = new MenuItem("Menu Principal");

            var product = new MenuItem("Produtos");
            product.Add(new MenuItem("Cadastrar Produtos", Product.AddProduct));
            product.Add(new MenuItem("Listar Produtos", Product.ListProduct));
            product.Add(new MenuItem("Editar Produtos", Product.EditProduct));
            product.Add(new MenuItem("Remover Produtos", Product.RemoveProduct));

            var funcionarios = new MenuItem("Funcionários");
            funcionarios.Add(new MenuItem("Cadastrar Funcionários", Employee.Add));
            funcionarios.Add(new MenuItem("Listar Funcionários", Employee.List));
            funcionarios.Add(new MenuItem("Editar Funcionários", Employee.Edit));
            funcionarios.Add(new MenuItem("Remover Funcionários", Employee.Remove));

            var clientes = new MenuItem("Clientes");
            clientes.Add(new MenuItem("Cadastrar Clientes", Client.Add));
            clientes.Add(new MenuItem("Listar Clientes", Client.List));
            clientes.Add(new MenuItem("Editar Clientes", Client.Edit));
            clientes.Add(new MenuItem("Remover Clientes", Client.Remove));

            var vendas = new MenuItem("Vendas");

            IReceiptDesign receiptDesign = new ReceiptDesign();
            var sales = new Sales(receiptDesign);
            vendas.Add(new MenuItem("Efetuar Venda", sales.SellItems));

            menu.Add(product);
            menu.Add(funcionarios);
            menu.Add(clientes);
            menu.Add(vendas);
            menu.Add(new MenuItem("Sair", () => Environment.Exit(0)));

            menu.Execute();

        }
    }
    

    public enum MenuType
    {
        Submenu,
        Command
    }
}
