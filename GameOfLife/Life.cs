namespace GameOfLife
{
    public class Life
    {
        public ICell[,] Cells { get; private set; }
        private readonly List<ICell> cells = new();

        public Life(int columns, int rows)
        {
            Cells = new ICell[columns, rows];
        }

        public void Tick()
        {
            ForEachCell(cell => cell.CalculateNextTick());
            ForEachCell(cell => cell.Tick());
        }

        public void ForEachCell(Action<ICell> predicate)
        {
            if (cells.Count == 0)
            {
                foreach (var cell in Cells)
                {
                    cells.Add(cell);
                }
            }

            cells.ForEach(predicate);
        }

    }
}
