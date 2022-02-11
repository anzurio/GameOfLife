using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class CellTests
    {
        private ICell CellUnderTest { get; set; }
        private Life Simulation { get; set; }


        [SetUp]
        public void Setup()
        {
            Simulation = new Life(3, 3);
            for (int i = 0; i < Simulation.Columns; i++)
            {
                for (int j = 0; j < Simulation.Rows; j++)
                {
                    var cell = new Cell();
                    Simulation[i, j] = cell;
                }
            }
            CellUnderTest = Simulation[1, 1];
        }

        [TestCase(0)]
        [TestCase(1)]
        public void CellDiesByUnderpopulation(int liveNeighbors)
        {
            // Given
            SetLiveNeighbors(liveNeighbors);
            CellUnderTest.IsAlive = true;

            // When
            CellUnderTest.CalculateNextTick();
            CellUnderTest.Tick();

            // Then
            Assert.IsFalse(CellUnderTest.IsAlive);
        }

        [TestCase(3)]
        [TestCase(2)]
        public void CellSurvivesByStasis(int liveNeighbors)
        {
            // Given
            SetLiveNeighbors(liveNeighbors);
            CellUnderTest.IsAlive = true;

            // When
            CellUnderTest.CalculateNextTick();
            CellUnderTest.Tick();

            // Then
            Assert.IsTrue(CellUnderTest.IsAlive);
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void CellDiesByOverpopulation(int liveNeighbors)
        {
            // Given
            SetLiveNeighbors(liveNeighbors);
            CellUnderTest.IsAlive = true;

            // When
            CellUnderTest.CalculateNextTick();
            CellUnderTest.Tick();

            // Then
            Assert.IsFalse(CellUnderTest.IsAlive);
        }

        [Test]
        public void CellRevivesByReproduction()
        {
            // Given
            SetLiveNeighbors(3);
            CellUnderTest.IsAlive = true;

            // When
            CellUnderTest.CalculateNextTick();
            CellUnderTest.Tick();

            // Then
            Assert.IsTrue(CellUnderTest.IsAlive);

        }

        private void SetLiveNeighbors(int liveNeighbors)
        {
            foreach (Cell cell in CellUnderTest.Cells)
            {
                if (cell != CellUnderTest && liveNeighbors-- > 0)
                {
                    cell.IsAlive = true;
                }
            }
        }

    }
}