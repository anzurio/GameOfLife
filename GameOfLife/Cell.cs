namespace GameOfLife
{
    public class Cell : ICell
    {
        public bool IsAlive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool WillLive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Row { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Column { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICell[,] Cells { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ICell> Neighbors { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void CalculateNextTick()
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }
    }
}
