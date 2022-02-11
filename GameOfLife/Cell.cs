namespace GameOfLife
{
    public class Cell : ICell
    {
        private readonly List<ICell> neighbors = new();

        public bool IsAlive { get; set; }
        public bool WillLive { get; set; }

        public int Row { get; set; }
        public int Column { get; set; }
        public ICell[,] Cells { get; set; }

        public List<ICell> Neighbors
        {
            get
            {
                if (neighbors.Count == 0)
                {
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (!(i == 0 && j == 0))
                            {
                                if (Column + i >= 0 && Column + i < Cells.GetLength(0) &&
                                    Row + j >= 0 && Row + j < Cells.GetLength(1))
                                {
                                    neighbors.Add(Cells[Column + i, Row + j]);
                                }
                            }
                        }
                    }
                }

                return neighbors;
            }
        }

        public void CalculateNextTick()
        {
            var aliveNeighbors = Neighbors.Count(x => x.IsAlive);
            if ((IsAlive && aliveNeighbors == 2) || (IsAlive && aliveNeighbors == 3))
            {
                WillLive = true;
            }
            else if (!IsAlive && aliveNeighbors == 3)
            {
                WillLive = true;
            }
            else
            {
                WillLive = false;
            }
        }

        public void Tick()
        {
            IsAlive = WillLive;
        }
    }
}
