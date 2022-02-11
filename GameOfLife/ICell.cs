namespace GameOfLife
{
    public interface ICell
    {
        public bool IsAlive { get; set; }
        public bool WillLive { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public ICell[,] Cells { get; set; }
        public List<ICell> Neighbors { get; }
        public void CalculateNextTick();
        public void Tick();
    }
}
