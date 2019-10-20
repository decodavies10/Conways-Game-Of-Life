using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLifeLibrary
{
    public enum CellState
    {
       Alive,
       Dead,
    }
    public class GameOfLife
    {
        public static CellState GetNewState(CellState currentState, int liveNeighbours)
        {
            if (liveNeighbours < 0 || liveNeighbours > 8)
                throw new ArgumentOutOfRangeException(nameof(liveNeighbours), "Number of live neighbours must be between 0 and 8");
            if (!Enum.IsDefined(typeof(CellState), currentState))
                throw new ArgumentException(nameof(currentState), "Invalid Cell State");

            switch (currentState)
            {
                //Checks Cells Alive
                case CellState.Alive:
                    //Checks Whether has Fewer Than 2 Live Nighbours Or More Than 3
                    if (liveNeighbours < 2 || liveNeighbours > 3)
                        //Returns Cell Dead
                        return CellState.Dead;
                    break;
                //Checks Cells Dead
                case CellState.Dead:
                    //Checks Whether Live Neighbours Equals 3
                    if (liveNeighbours == 3)
                        //Returns Cell Alive
                        return CellState.Alive;
                    break;
            }
            //Returns Cells Current State
            return currentState;
        }
    }
}
