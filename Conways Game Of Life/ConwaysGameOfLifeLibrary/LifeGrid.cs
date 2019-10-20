using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwaysGameOfLifeLibrary;

namespace ConwaysGameOfLifeLibrary
{
    public class LifeGrid
    {
        int gridHeight;
        int gridWidth;

        public CellState[,] currentState;
        private CellState[,] nextState;

        public LifeGrid(int height, int width)
        {
            gridHeight = height;
            gridWidth = width;

            currentState = new CellState[gridHeight, gridWidth];
            nextState = new CellState[gridHeight, gridWidth];

            for (int i = 0; i < gridHeight; i++)
                for (int j = 0; j < gridWidth; j++)
                {
                    currentState[i, j] = CellState.Dead;
                }

        }
        public void UpdateState()
        {
            for (int i = 0; i < gridHeight; i++)
                for (int j = 0; j < gridWidth; j++)
                {
                    var liveNeighbors = GetLiveNeighbours(i, j);
                    nextState[i, j] = GameOfLife.GetNewState(currentState[i, j], liveNeighbors);
                }

            currentState = nextState;
            nextState = new CellState[gridHeight, gridWidth];
        }
        private int GetLiveNeighbours(int positionX, int positionY)
        {
            int liveNeighbours = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborX = positionX + i;
                    int neighborY = positionY + j;

                    if(neighborX >= 0 && neighborX < gridHeight && neighborY >=0 && neighborY < gridWidth)
                    {
                        if (currentState[neighborX, neighborY] == CellState.Alive)
                            liveNeighbours++;
                    }
                }

            return liveNeighbours;
        }
        public static void ShowGrid(CellState[,] currentState)
        {
            Console.Clear();

            int x = 0;
            int rowLength = currentState.GetUpperBound(1) + 1;

            var output = new StringBuilder();
            foreach (var state in currentState)
            {
                output.Append(state == CellState.Alive ? "O" : ".");
                x++;

                if (x >= rowLength)
                {
                    x = 0;
                    output.AppendLine();
                }
            }
            Console.WriteLine(output.ToString());
        }
        public void Randomize()
        {
            Random random = new Random();

            for(int i=0; i <gridHeight; i++)
                for (int j = 0; j < gridWidth; j++)
                {
                    var next = random.Next(2);
                    var newState = next < 1 ? CellState.Dead : CellState.Alive;
                    currentState[i, j] = newState;
                }
        }
    }
}
