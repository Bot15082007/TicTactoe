using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe
{
    public class Form1 : Form
    {
        private Button button1, button2, button3, button4, button5, button6, button7, button8, button9;
        private Button button10; 
        private Label label1, label2, label3;  

        
        string current_player;   
        int turn_count;  
        Button[,] buttons; 

        public Form1()
        {
            InitializeUi();

            // шаги 4 и 14
            label2.Text = "";
            label3.Text = "";
            ResetGame();
        }
        private void InitializeUi()
        {
            Text = "Form1";
            ClientSize = new Size(340, 420);
            StartPosition = FormStartPosition.CenterScreen;

            label2 = new Label();
            label2.Left = 90; label2.Top = 25; label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11);

            button1 = MakeCell(60, 70);  button2 = MakeCell(145, 70);  button3 = MakeCell(230, 70);
            button4 = MakeCell(60, 150); button5 = MakeCell(145, 150); button6 = MakeCell(230, 150);
            button7 = MakeCell(60, 230); button8 = MakeCell(145, 230); button9 = MakeCell(230, 230);

            label1 = new Label();
            label1.Text = "Ход:";
            label1.Left = 30; label1.Top = 325; label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12);

            label3 = new Label();
            label3.Left = 90; label3.Top = 327; label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            button10 = new Button();
            button10.Text = "начать заново";
            button10.Left = 30; button10.Top = 365; button10.Width = 160; button10.Height = 32;
            button10.Click += button10_Click;

            Controls.Add(label2);
            Controls.Add(button1); Controls.Add(button2); Controls.Add(button3);
            Controls.Add(button4); Controls.Add(button5); Controls.Add(button6);
            Controls.Add(button7); Controls.Add(button8); Controls.Add(button9);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(button10);
        }
        private Button MakeCell(int x, int y)
        {
            Button b = new Button();
            b.Left = x; b.Top = y; b.Width = 65; b.Height = 65;
            b.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            return b;
        }
        private void Disabled_btn()
        {
            foreach (Button btn in buttons)
            {
                btn.Enabled = false;
            }
        }
        private bool CheckRows()
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[i, 0].Text == current_player &&
                    buttons[i, 1].Text == current_player &&
                    buttons[i, 2].Text == current_player)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckColumns()
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[0, i].Text == current_player &&
                    buttons[1, i].Text == current_player &&
                    buttons[2, i].Text == current_player)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDiagonals()
        {
            if (buttons[0, 0].Text == current_player &&
                buttons[1, 1].Text == current_player &&
                buttons[2, 2].Text == current_player)
            {
                return true;
            }
            if (buttons[0, 2].Text == current_player &&
                buttons[1, 1].Text == current_player &&
                buttons[2, 0].Text == current_player)
            {
                return true;
            }
            return false;
        }
        private bool CheckForWinner()
        {
            return (CheckRows() || CheckColumns() || CheckDiagonals());
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Text = current_player;
            clickedButton.Enabled = false;
            turn_count++;

            if (CheckForWinner())
            {
                label2.Text = $"Игрок {current_player} выиграл!";
                Disabled_btn();
            }
            else if (turn_count == 9)
            {
                label2.Text = "Ничья!";
            }
            else
            {
                current_player = (current_player == "X") ? "O" : "X";
                label3.Text = $"{current_player}";
            }
        }
        private void ResetGame()
        {
            current_player = "X";
            label3.Text = $"{current_player}";
            turn_count = 0;
            buttons = new Button[3, 3]
            {
                { button1, button2, button3 },
                { button4, button5, button6 },
                { button7, button8, button9 }
            };
            foreach (Button btn in buttons)
            {
                btn.Text = string.Empty;
                btn.Enabled = true;
                btn.Click -= Button_Click; 
                btn.Click += Button_Click;
            }
            label2.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
