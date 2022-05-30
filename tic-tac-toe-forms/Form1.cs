using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe_forms
{
    public partial class Form1 : Form
    {

        Dictionary<FieldType, String> symbols = new Dictionary<FieldType, string>(3);

        private Game game = new Game();
  

        private Button[,] buttons = new Button[3, 3];
        public Form1()
        {
            game.Win += onWin;
            game.mapChanged += onNewStep;
            symbols.Add(FieldType.o, "o");
            symbols.Add(FieldType.x, "x");
            symbols.Add(FieldType.empty, "");

            InitializeComponent();
            this.Height = 700;
            this.Width = 900;
            /*            player = 1;
                        label2.Text = "Текущий ход: Игрок 1";
                        for (int i = 0; i < buttons.Length / 3; i++)
                        {
                            for (int j = 0; j < buttons.Length / 3; j++)
                            {
                                buttons[i, j] = new Button();
                                buttons[i, j].Size = new Size(200, 200);
                            }
                        }*/
            setButtons();

        }

        private void onWin(FieldType obj)
        {
            MessageBox.Show("Хрестики виграли");
        }

        private void onNewStep(FieldType[,] obj)
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j].Text = symbols[obj[i, j]];
                    buttons[i, j].Enabled = obj[i, j] == FieldType.empty;
                }
            }
        }

        private void setButtons()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Location = new Point(12 + 206 * j, 12 + 206 * i);
                    buttons[i, j].Size = new System.Drawing.Size(200, 200);
                    buttons[i, j].Click += button1_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 80);
                    buttons[i, j].Text = "";
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i, j] == sender)
                    {
                        game.OnNewStep(i, j);
                    }
                }

            }

            checkWin();

        }
        private void checkWin()
        {
            game.CheckWin();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonPlay_Click_1(object sender, EventArgs e)
        {
            game.Reset();
        }


    }
}
