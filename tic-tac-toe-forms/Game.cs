using System;
using System.Collections.Generic;
using System.Text;

namespace tic_tac_toe_forms
{
    public enum FieldType
    {
        empty,
        x,
        o,

    }
    class Game
    {




        public Game()
        {
      
            symbols.Add(0, FieldType.o);
            symbols.Add(1, FieldType.x);
        }
        public event Action<FieldType> Win;
        public event Action<FieldType[,]> mapChanged;

        private FieldType[,] buttons = new FieldType[3, 3];
        private int currentPlayer = 0;
        public int i = 0;
        Dictionary<int, FieldType> symbols = new Dictionary<int, FieldType>(2);
        List<Command> commands = new List<Command>();

        public void OnNewStep(int i, int j)
        {
            if (buttons[i, j] != FieldType.empty)
            {
                return;
            }
            buttons[i, j] = symbols[currentPlayer];
            mapChanged(buttons);
            currentPlayer++;
            currentPlayer %= 2;
        }
        public void Reset()
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j] = FieldType.empty;
                }
            }
            mapChanged(buttons);
        }
        public void Undo()
        {

        }
        public void CheckWin()
        {
            
            if (buttons[0, 0] == buttons[0, 1] && buttons[0, 1] == buttons[0, 2])
            {

                if (buttons[0, 0] != FieldType.empty)
                {
                    Win(buttons[0, 0]);
                    return;
                }
            }
            if (buttons[1, 0] == buttons[1, 1] && buttons[1, 1] == buttons[1, 2])
            {
                if (buttons[1, 0] != FieldType.empty)
                    Win(buttons[0, 0]);
            }
            if (buttons[2, 0] == buttons[2, 1] && buttons[2, 1] == buttons[2, 2])
            {
                if (buttons[2, 0] != FieldType.empty)
                    Win(buttons[0, 0]);
            }
            if (buttons[0, 0] == buttons[1, 0] && buttons[1, 0] == buttons[2, 0])
            {
                if (buttons[0, 0] != FieldType.empty)
                    Win(buttons[0, 0]);
            }
            if (buttons[0, 1] == buttons[1, 1] && buttons[1, 1] == buttons[2, 1])
            {
                if (buttons[0, 1] != FieldType.empty)
                {
                    Win(buttons[0, 0]);
                }

            }
            if (buttons[0, 2] == buttons[1, 2] && buttons[1, 2] == buttons[2, 2])
            {
                if (buttons[0, 2] != FieldType.empty)
                    Win(buttons[0, 0]);
            }
            if (buttons[0, 0] == buttons[1, 1] && buttons[1, 1] == buttons[2, 2])
            {
                if (buttons[0, 0] != FieldType.empty)
                    Win(buttons[0, 0]);
            }
            if (buttons[2, 0] == buttons[1, 1] && buttons[1, 1] == buttons[0, 2])
            {
                if (buttons[2, 0] != FieldType.empty)
                    Win(buttons[0, 0]);
            }
        }
        public void UndoStep()
        {
            Console.WriteLine("Телевизор выключен...");
        }

    }
}
