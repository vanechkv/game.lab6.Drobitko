using System;
using System.Collections.Generic;

namespace game.lab6.Drobitko
{
    public class Board
    {
        public int Size { get; private set; }
        public Dictionary<Tuple<int, int>, Cell> Cells { get; private set; }
        private List<Ship> ships;

        public Board(int size)
        {
            Size = size;
            Cells = new Dictionary<Tuple<int, int>, Cell>();
            ships = new List<Ship>();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cells.Add(Tuple.Create(i, j), new Cell());
                }
            }
        }

        public bool CanPlaceShip(Ship ship, int x, int y, bool horizontal)
        {
            if (horizontal)
            {
                if (y + ship.Size > Size)
                    return false;
                for (int i = y; i < y + ship.Size; i++)
                {
                    if (Cells[Tuple.Create(x, i)].Ship != null || HasAdjacentShip(x, i))
                        return false;
                }
            }
            else
            {
                if (x + ship.Size > Size)
                    return false;
                for (int i = x; i < x + ship.Size; i++)
                {
                    if (Cells[Tuple.Create(i, y)].Ship != null || HasAdjacentShip(i, y))
                        return false;
                }
            }
            return true;
        }

        public void PlaceShip(Ship ship, int x, int y, bool horizontal)
        {
            if (horizontal)
            {
                for (int i = y; i < y + ship.Size; i++)
                {
                    Cells[Tuple.Create(x, i)].Ship = ship;
                }
            }
            else
            {
                for (int i = x; i < x + ship.Size; i++)
                {
                    Cells[Tuple.Create(i, y)].Ship = ship;
                }
            }
            ships.Add(ship);
        }
        public void ClearShips()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Cells[Tuple.Create(i, j)].Ship = null;
                }
            }
        }

        public bool MakeHit(Tuple<int, int> coordinates)
        {
            if (!Cells.ContainsKey(coordinates))
                return false;

            Cell cell = Cells[coordinates];
            if (cell.Hit) 
                return false;

            cell.Hit = true;

            if (cell.Ship != null)
            {
                cell.Ship.Hit();
                if (cell.Ship.IsSunk)
                {
                    MarkSurroundingCells(cell.Ship);
                }
                return true;
            }
            return false;
        }


        public bool CheckLost()
        {
            foreach (var ship in ships)
            {
                if (!ship.IsSunk)
                    return false;
            }
            return true;
        }

        private bool HasAdjacentShip(int x, int y)
        {
            int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1 };
            int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1 };

            for (int i = 0; i < dx.Length; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx >= 0 && nx < Size && ny >= 0 && ny < Size)
                {
                    if (Cells[Tuple.Create(nx, ny)].Ship != null)
                        return true;
                }
            }
            return false;
        }

        public void MarkSurroundingCells(Ship ship)
        {
            foreach (var cell in Cells)
            {
                if (cell.Value.Ship == ship)
                {
                    int x = cell.Key.Item1;
                    int y = cell.Key.Item2;

                    int[] dx = { -1, 0, 1, -1, 1, -1, 0, 1, 0 };
                    int[] dy = { -1, -1, -1, 0, 0, 1, 1, 1, 0 };

                    for (int i = 0; i < dx.Length; i++)
                    {
                        int nx = x + dx[i];
                        int ny = y + dy[i];

                        if (nx >= 0 && nx < Size && ny >= 0 && ny < Size)
                        {
                            Cells[Tuple.Create(nx, ny)].Hit = true;
                        }
                    }
                }
            }
        }

    }
}
