namespace LetsMarket.Menu4
{
    public class MenuItem
    {
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
        }

        public MenuItem(string title, Action action) : this(title)
        {
            this.action = action;
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


            if (action != null && items.Count == 0)
            {
                action();
                Console.ReadLine();

                _root.Execute();
            }
            else
            {
                var key = new ConsoleKeyInfo();
                do
                {
                    Console.ResetColor();
                    Console.Clear();

                    //Console.WriteLine(Center(title.ToUpperInvariant()));
                    Console.WriteLine(title.ToUpperInvariant());
                    Console.WriteLine(new String('-', Console.WindowWidth));

                    for (int i = 0; i < items.Count; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        Console.WriteLine(items[i]);
                    }

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
                            //selectedIndex = 0;
                            items[selectedIndex].Execute();
                            break;
                        default:
                            break;
                    }


                } while (key.Key != ConsoleKey.Escape);
            }
        }

        //private string Center(string v)
        //{
        //    int size = (Console.WindowWidth - v.Length) / 2;
        //    return v.PadLeft(size).PadRight(Console.WindowWidth - size);
        //}

        public override string ToString()
        {
            return title;
        }
    }
}
