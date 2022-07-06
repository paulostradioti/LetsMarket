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
                    var lineSeparator = $"|{new String('-', menuTitle.Length - 2)}|";

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
    }

    public enum MenuType
    {
        Submenu,
        Command
    }
}
