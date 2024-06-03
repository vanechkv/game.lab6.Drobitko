using System;
using System.Collections.Generic;

namespace game.lab6.Drobitko
{
    public class Game
    {
        public List<Player> Players { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public Player Winner { get; private set; }
        private int currentPlayerIndex;
        private Random random;

        public Game(string player1Name, string player2Name, int boardSize)
        {
            Players = new List<Player>
            {
                new Player(player1Name, boardSize),
                new Player(player2Name, boardSize)
            };
            random = new Random();
            currentPlayerIndex = random.Next(Players.Count);
            CurrentPlayer = Players[currentPlayerIndex];
        }

        public void SwitchTurn()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % Players.Count;
            CurrentPlayer = Players[currentPlayerIndex];
        }

        public bool MakeHit(Tuple<int, int> coordinates, Player targetPlayer)
        {
            bool hitSuccessful = targetPlayer.Board.MakeHit(coordinates);
            if (!hitSuccessful)
                SwitchTurn();
            return hitSuccessful;
        }

        public bool CheckEndGame()
        {
            foreach (var player in Players)
            {
                if (player.Board.CheckLost())
                {
                    Winner = Players[(currentPlayerIndex + 1) % Players.Count];
                    return true;
                }
            }
            return false;
        }
    }
}
