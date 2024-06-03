using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace game.lab6.Drobitko
{
    public partial class GameForm : Form
    {
        private Game game;
        private bool isHorizontal = true;
        private Ship selectedShip;
        private bool player1Ready = false;
        private bool player2Ready = false;
        private Player currentPlayer;

        public GameForm(string player1Name, string player2Name, int boardSize)
        {
            InitializeComponent();
            InitializeGame(player1Name, player2Name, boardSize);
        }

        private void InitializeGame(string player1Name, string player2Name, int boardSize)
        {
            game = new Game(player1Name, player2Name, boardSize);
            currentPlayer = game.Players[0];
            currentPlayerLabel.Visible = false;
            PopulateShipList();
            InitializeBoardPanels(boardSize);
            UpdatePlayerNames();
        }

        private void UpdatePlayerNames()
        {
            player1NameLabel.Text = game.Players[0].Name;
            player2NameLabel.Text = game.Players[1].Name;
        }

        private void PopulateShipList()
        {
            shipListBox.Items.Clear();
            shipListBox.Items.Add(new Ship(4));
            shipListBox.Items.Add(new Ship(3));
            shipListBox.Items.Add(new Ship(3));
            shipListBox.Items.Add(new Ship(2));
            shipListBox.Items.Add(new Ship(2));
            shipListBox.Items.Add(new Ship(2));
            shipListBox.Items.Add(new Ship(1));
            shipListBox.Items.Add(new Ship(1));
            shipListBox.Items.Add(new Ship(1));
            shipListBox.Items.Add(new Ship(1));
        }

        private void InitializeBoardPanels(int boardSize)
        {
            InitializeBoardPanel(player1BoardPanel, boardSize);
            InitializeBoardPanel(player2BoardPanel, boardSize);
            player2BoardPanel.Visible = false;
        }

        private void InitializeBoardPanel(Panel panel, int boardSize)
        {
            panel.Controls.Clear();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Button button = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(j * 30, i * 30),
                        Tag = Tuple.Create(i, j),
                    };
                    button.Click += (panel == player1BoardPanel) ? new EventHandler(Player1Button_Click) : new EventHandler(Player2Button_Click);
                    panel.Controls.Add(button);
                }
            }
        }

        private void ShipListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShip = shipListBox.SelectedItem as Ship;
        }

        private void ReadyButton_Click(object sender, EventArgs e)
        {
            if (currentPlayer == game.Players[0])
            {
                if (shipListBox.Items.Count > 0)
                {
                    MessageBox.Show("Разместите все корабли перед началом игры.");
                    return;
                }

                player1Ready = true;
                readyButton.Text = "Player 2 Ready";
                shipListBox.Items.Clear();
                PopulateShipList();
                currentPlayer = game.Players[1];
                player1BoardPanel.Visible = false;
                player2BoardPanel.Visible = true;
            }
            else
            {
                if (shipListBox.Items.Count > 0)
                {
                    MessageBox.Show("Разместите все корабли перед началом игры.");
                    return;
                }

                player2Ready = true;
                readyButton.Enabled = false;
                StartGame();
            }
        }

        private void StartGame()
        {
            MessageBox.Show("Оба игрока готовы. Начинается игра!");
            UpdateShipButtons(player1BoardPanel);
            UpdateShipButtons(player2BoardPanel);
            currentPlayerLabel.Visible = true;
            clearBoardButton.Visible = false;
            InitializeGamePlay();
        }

        private void InitializeGamePlay()
        {
            currentPlayer = new Random().Next(0, 2) == 0 ? game.Players[0] : game.Players[1];
            UpdatePlayerTurn();
        }

        private void UpdatePlayerTurn()
        {
            UpdatePlayerTurnLabel();
            if (currentPlayer == game.Players[0])
            {
                player2BoardPanel.Visible = false;
                player1BoardPanel.Visible = true;
                player1BoardPanel.Enabled = true;
            }
            else
            {
                player1BoardPanel.Visible = false;
                player2BoardPanel.Visible = true;
                player2BoardPanel.Enabled = true;
            }
        }

        private void UpdatePlayerTurnLabel()
        {
            currentPlayerLabel.Text = $"{currentPlayer.Name} ходит";
        }

        private void HandleShipPlacement(Button button, Player player)
        {
            if (selectedShip == null)
                return;

            var coordinates = button.Tag as Tuple<int, int>;
            if (coordinates == null)
                return;

            int x = coordinates.Item1;
            int y = coordinates.Item2;

            if (player.Board.CanPlaceShip(selectedShip, x, y, isHorizontal))
            {
                player.Board.PlaceShip(selectedShip, x, y, isHorizontal);

                for (int i = 0; i < selectedShip.Size; i++)
                {
                    int cx = isHorizontal ? x : x + i;
                    int cy = isHorizontal ? y + i : y;

                    Button cellButton = FindCellButton(player == game.Players[0] ? player1BoardPanel : player2BoardPanel, cx, cy);
                    if (cellButton != null)
                    {
                        cellButton.BackColor = Color.Blue;
                        cellButton.Tag = Tuple.Create(cx, cy, selectedShip);
                    }
                }

                shipListBox.Items.Remove(selectedShip);
                selectedShip = null;
            }
            else
            {
                MessageBox.Show("Корабль не может быть размещен в данной позиции.");
            }
        }

        private Button FindCellButton(Panel boardPanel, int x, int y)
        {
            foreach (Control ctrl in boardPanel.Controls)
            {
                Button cellButton = ctrl as Button;
                if (cellButton != null)
                {
                    var tag = cellButton.Tag as Tuple<int, int>;
                    if (tag != null && tag.Item1 == x && tag.Item2 == y)
                    {
                        return cellButton;
                    }
                }
            }
            return null;
        }

        private void Player1Button_Click(object sender, EventArgs e)
        {
            if (!player1Ready)
            {
                HandleShipPlacement(sender as Button, game.Players[0]);
            }
            else if (player2Ready)
            {
                AttackButton(sender as Button, game.Players[1]);
            }
        }

        private void Player2Button_Click(object sender, EventArgs e)
        {
            if (!player2Ready)
            {
                HandleShipPlacement(sender as Button, game.Players[1]);
            }
            else if (player1Ready)
            {
                AttackButton(sender as Button, game.Players[0]);
            }
        }

        private void AttackButton(Button button, Player targetPlayer)
        {
            var coordinates = button.Tag as Tuple<int, int>;
            if (coordinates == null || targetPlayer.Board.Cells[coordinates].Hit)
            {
                MessageBox.Show("По этой клетке уже был нанесен удар.");
                return;
            }

            if (game.MakeHit(coordinates, targetPlayer))
            {
                button.BackColor = Color.Red;
                var ship = targetPlayer.Board.Cells[coordinates].Ship;
                if (ship != null && ship.IsSunk)
                {
                    string message = $"{currentPlayer.Name} уничтожил {ship.Size}-палубный корабль.";
                    MessageBox.Show(message);

                    targetPlayer.Board.MarkSurroundingCells(ship);
                    UpdateBoardPanel(targetPlayer == game.Players[1] ? player1BoardPanel : player2BoardPanel, targetPlayer);
                }

                if (targetPlayer.Board.CheckLost())
                {
                    MessageBox.Show($"{currentPlayer.Name} победил!");
                    this.Close();
                }
            }
            else
            {
                button.BackColor = Color.Gray;
                currentPlayer = currentPlayer == game.Players[0] ? game.Players[1] : game.Players[0];
                UpdatePlayerTurn();
            }
        }
        private void UpdateBoardPanel(Panel boardPanel, Player player)
        {
            foreach (Control ctrl in boardPanel.Controls)
            {
                Button cellButton = ctrl as Button;
                if (cellButton != null)
                {
                    var tag = cellButton.Tag as Tuple<int, int>;
                    if (tag != null)
                    {
                        int x = tag.Item1;
                        int y = tag.Item2;
                        if (player.Board.Cells[Tuple.Create(x, y)].Hit)
                        {
                            if (cellButton.BackColor != Color.Red)
                            {
                                cellButton.BackColor = Color.Gray;
                            }
                        }
                    }
                }
            }
        }


        private void HorizontalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isHorizontal = horizontalRadioButton.Checked;
        }

        private void VerticalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isHorizontal = !verticalRadioButton.Checked;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            horizontalRadioButton.Checked = true;
        }

        private void UpdateShipButtons(Panel boardPanel)
        {
            foreach (Control ctrl in boardPanel.Controls)
            {
                Button cellButton = ctrl as Button;
                if (cellButton != null)
                {
                    var tag = cellButton.Tag as Tuple<int, int, Ship>;
                    if (tag != null)
                    {
                        cellButton.BackColor = Color.White;
                        cellButton.Tag = Tuple.Create(tag.Item1, tag.Item2);
                    }
                }
            }
        }

        private void ClearBoardButton_Click(object sender, EventArgs e)
        {
            Panel boardPanel = currentPlayer == game.Players[0] ? player1BoardPanel : player2BoardPanel;
            foreach (Control ctrl in boardPanel.Controls)
            {
                Button cellButton = ctrl as Button;
                if (cellButton != null && cellButton.BackColor == Color.Blue)
                {
                    var tag = cellButton.Tag as Tuple<int, int, Ship>;
                    if (tag != null)
                    {
                        if (!shipListBox.Items.Contains(tag.Item3))
                        {
                            shipListBox.Items.Add(tag.Item3);
                        }

                        cellButton.BackColor = Color.White;
                        cellButton.Tag = Tuple.Create(tag.Item1, tag.Item2);
                    }
                }
            }

            currentPlayer.Board.ClearShips();
        }
    }
}
