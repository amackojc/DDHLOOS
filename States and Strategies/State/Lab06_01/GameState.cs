using System;
using System.Collections.Generic;
using System.Text;

namespace Lab06_01
{
    abstract class GameState
    {
        protected GameApp parentApp;

        public GameState(GameApp app)
        {
            parentApp = app;
        }

        public abstract void EnterButton();
        public abstract void EscapeButton();
        public abstract void TabButton();
        public abstract void KeyboardInput();

    }

    class MenuState : GameState
    {
        public MenuState(GameApp app) : base(app)
        {
            Console.WriteLine("Welcome in menu!");
        }

        public override void EnterButton()
        {
            Console.WriteLine("Starting game...");
            parentApp.ChangeState(new InGameState(this.parentApp));
        }

        public override void EscapeButton() { }
        public override void KeyboardInput() { }

        public override void TabButton() { }

    }
    class InGameState : GameState
    {
        public InGameState(GameApp app) : base(app)
        {
            Console.WriteLine("Let's start playing!");
        }

        public override void EnterButton()
        {
            Console.WriteLine("Openning Chat...");
            parentApp.ChangeState(new ChatState(this.parentApp));

        }

        public override void EscapeButton()
        {
            Console.WriteLine("Returning to menu...");
            parentApp.ChangeState(new MenuState(this.parentApp));
        }

        public override void KeyboardInput() { }

        public override void TabButton()
        {
            Console.WriteLine("Opening shop...");
            parentApp.ChangeState(new ShopState(this.parentApp));
        }

        class ChatState : GameState
        {
            public ChatState(GameApp app) : base(app)
            {
                Console.WriteLine("Welcome in chat!");
            }

            public override void EnterButton()
            {
                Console.WriteLine("Closing chat...");
                parentApp.ChangeState(new InGameState(this.parentApp));
            }

            public override void EscapeButton()
            {
                Console.WriteLine("Closing chat...");
                parentApp.ChangeState(new InGameState(this.parentApp));
            }

            public override void KeyboardInput()
            {
                string message = Console.ReadLine();
                Console.WriteLine("Your message is:" + message);
            }

            public override void TabButton() { }
        }

        class ShopState : GameState
        {
            public ShopState(GameApp app) : base(app)
            {
                Console.WriteLine("Welcome in shop!");
            }

            public override void EnterButton()
            {
                Console.WriteLine("Opening chat...");
                parentApp.ChangeState(new ChatState(this.parentApp));
            }

            public override void EscapeButton()
            {
                Console.WriteLine("Closing shop...");
                parentApp.ChangeState(new InGameState(this.parentApp));
            }

            public override void KeyboardInput()
            {
                var random = new Random();
                var items = new List<string>()
                {
                    "Armour",
                    "Long sword",
                    "Halberd",
                    "Arc",
                    "Elixir of life"
                };
                int index = random.Next(items.Count);
                Console.WriteLine("You bought " + items[index] + "! Visit us again!");
            }

            public override void TabButton()
            {
                Console.WriteLine("Closing shop...");
                parentApp.ChangeState(new InGameState(this.parentApp));
            }
        }
    }
}
