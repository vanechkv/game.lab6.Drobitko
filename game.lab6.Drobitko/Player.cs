namespace game.lab6.Drobitko
{
    public class Player
    {
        public string Name { get; private set; }
        public Board Board { get; private set; }

        public Player(string name, int boardSize)
        {
            Name = name;
            Board = new Board(boardSize);
        }

        public bool CheckLost()
        {
            return Board.CheckLost();
        }
    }
}
