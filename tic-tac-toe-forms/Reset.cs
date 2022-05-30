using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe_forms
{
    class Reset : Command
    {
        Game game;

         public Reset(Game game)
        {
            this.game = game;
        }

        public void Execute()
        {
            game.Reset();
        }
    }
}
