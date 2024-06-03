namespace game.lab6.Drobitko
{
    public class Ship
    {
        public int Size { get; private set; }
        public bool IsSunk { get; private set; }
        private int hitCount;

        public Ship(int size)
        {
            Size = size;
            IsSunk = false;
            hitCount = 0;
        }

        public void Hit()
        {
            hitCount++;
            if (hitCount >= Size)
                IsSunk = true;
        }

        public override string ToString()
        {
            return $"Корабль (Размер: {Size})";
        }
    }
}
