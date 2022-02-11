using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class CellTests
    {
        private Cell CellUnderTest { get; set; }
        private Cell[,] Cells { get; set; }


        [SetUp]
        public void Setup()
        {
            Cells = new Cell[3, 3];
        }

        [TestCase(0)]
        [TestCase(1)]
        public void CellDiesByUnderpopulation(int liveNeighbors)
        {
            // Given
            SetScenario(liveNeighbors);
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
            SetScenario(liveNeighbors);
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
            SetScenario(liveNeighbors);
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
            SetScenario(3);
            CellUnderTest.IsAlive = true;

            // When
            CellUnderTest.CalculateNextTick();
            CellUnderTest.Tick();

            // Then
            Assert.IsTrue(CellUnderTest.IsAlive);

        }

        private void SetScenario(int liveNeighbors)
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    var cell = new Cell();
                    Cells[i, j] = cell;
                    cell.Column = i;
                    cell.Row = j;
                    cell.Cells = Cells;


                }
            }
            CellUnderTest = Cells[1, 1];

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