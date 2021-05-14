using System;

namespace Lab06_01
{
    class Program
    {
        static void Main(string[] args)
        {
            var state = new GameApp();

            state.EnterButton(); // Menu -> Game
            state.TabButton(); // Game -> Shop
            state.KeyboardInput(); // Display item
            state.EscapeButton(); // Shop -> Menu

        }
    }
}
