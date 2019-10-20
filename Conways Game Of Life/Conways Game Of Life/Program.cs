using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwaysGameOfLifeLibrary;

namespace Conways_Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new LifeGrid(15, 25);
            grid.Randomize();

            grid.currentState[1, 2] = CellState.Alive;
            grid.currentState[2, 2] = CellState.Alive;
            grid.currentState[3, 2] = CellState.Alive;

            LifeGrid.ShowGrid(grid.currentState);

            while (Console.ReadLine() != "q")
            {
                grid.UpdateState();
                LifeGrid.ShowGrid(grid.currentState);
            }

        }
    }
}
