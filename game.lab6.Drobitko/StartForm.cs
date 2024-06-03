using System;
using System.Windows.Forms;

namespace game.lab6.Drobitko
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            string player1Name = player1TextBox.Text;
            string player2Name = player2TextBox.Text;
            int boardSize = 10;

            GameForm gameForm = new GameForm(player1Name, player2Name, boardSize);
            gameForm.ShowDialog();
        }
    }
}
