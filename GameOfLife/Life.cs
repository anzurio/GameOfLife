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

    }
}
