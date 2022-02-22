namespace GameOfLife
{
    public class Life
    {
        public ICell[,] Cells { get; private set; }
        private readonly List<ICell> cells = new();

        public Life(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            Cells = new ICell[columns, rows];
        }

        public int Columns { get; private set; }
        
        public int Rows { get; private set; }
        

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

        public ICell this[int i, int j]
        {
            get
            {
                return Cells[i,j];
            }
            set
            {
                Cells[i,j] = value;
                value.Cells = this.Cells;
                value.Column = i;
                value.Row = j;
            }
        }

    }
}
