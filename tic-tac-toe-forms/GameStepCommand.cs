using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe_forms
{
    class GameStepCommand : Command
    {
        
        private String[,] buttons = new String[3, 3];
        public GameStepCommand(String[,] buttons)
        {
            this.buttons = buttons;
        }
        public void Execute()
        {

        }
   
    }
}
