namespace EventHandlerExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione a tecla P");
            var p = Console.ReadLine();
            if (p == "p")
            {
                KeyPressed();
            }
        }

        static void KeyPressed()
        {
            Button button = new Button();
            button.OnClickEvent += (s, args) =>
            {
                Console.WriteLine($"{args.Name}, Você clicou no botão");
            };
            button.Click();
        }
    }

    public class Button
    {
        public event EventHandler<MyCustomArguments>? OnClickEvent;
        MyCustomArguments customArguments = new MyCustomArguments();
        public void Click()
        {
            customArguments.Name = "Pedro";
            OnClickEvent?.Invoke(this, customArguments);
        }
    }

    public class MyCustomArguments : EventArgs
    {
        public string? Name { get; set; }
    }
}