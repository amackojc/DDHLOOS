using System;
using System.Collections.Generic;
using System.Text;

namespace Lab06_01
{
    class GameApp
    {
        private GameState currentState;

        public GameApp()
        {
            currentState = new MenuState(this);
        }

        public void ChangeState(GameState newState)
        {
            currentState = newState;
        }

        public void EnterButton()
        {
            currentState.EnterButton();
        }
        public void EscapeButton()
        {
            currentState.EscapeButton();
        }
        public void TabButton()
        {
            currentState.TabButton();
        }
        public void KeyboardInput()
        {
            currentState.KeyboardInput();
        }

    }
}
