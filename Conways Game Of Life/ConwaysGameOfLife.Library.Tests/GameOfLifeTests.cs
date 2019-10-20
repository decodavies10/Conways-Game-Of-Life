using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConwaysGameOfLifeLibrary;

namespace ConwaysGameOfLife.Library.Tests
{
    //Any live cell with fewer than two live neighbours dies.
    //Any live cell with two or three live neighbours lives.
    //Any live cell with more than three neighbouts dies.
    //Any dead cell with exactly three live neighbours becommes a live cell.
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void LiveCell_FewerThan2LiveNeighbours_Dies([Values(0, 1)] int liveNeighbours)
        {
            //Arrange
            var currentState = CellState.Alive;

            //Act
            CellState newState = GameOfLife.GetNewState(currentState, liveNeighbours);

            //Assert
            Assert.AreEqual(CellState.Dead, newState);
        }
        [Test]
        public void LiveCell_TwoOrThreeLiveNighbours_Lives([Values(2, 3)] int liveNeighbours)
        {
            //Arrange
            var currentState = CellState.Alive;

            //Act
            CellState newState = GameOfLife.GetNewState(currentState, liveNeighbours);

            //Assert
            Assert.AreEqual(CellState.Alive, newState);
        }
        [Test]
        public void LiveCell_ThreeLiveNighbours_Alive([Values(3)] int liveNeighbours)
        {
            //Arrange
            var currentState = CellState.Dead;

            //Act
            CellState newState = GameOfLife.GetNewState(currentState, liveNeighbours);

            //Assert
            Assert.AreEqual(CellState.Alive, newState);
        }
        [Test]
        public void DeadCell_MoreThanThreeLiveNighbours_Dies([Values(4, 5, 6, 7, 8)] int liveNeighbours)
        {
            //Arrange
            var currentState = CellState.Dead;

            //Act
            CellState newState = GameOfLife.GetNewState(currentState, liveNeighbours);

            //Assert
            Assert.AreEqual(CellState.Dead, newState);
        }
        [Test]
        public void DeadCell_FewerThanThreeLiveNeighbours_StaysDead([Range(0, 2)] int liveNeighbours)
        {
            //Arrange
            var currentState = CellState.Dead;

            //Act
            CellState newState = GameOfLife.GetNewState(currentState, liveNeighbours);

            //Assert
            Assert.AreEqual(CellState.Dead, newState);
        }
    }
}
