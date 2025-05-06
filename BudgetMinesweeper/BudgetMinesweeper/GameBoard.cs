using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMinesweeper
{
    class GameBoard
    {
        int boardLength;
        int boardWidth;
        int numMines = 0;
        public DigSpot[][] minefield; //How to declare a 2D array

        public GameBoard(int length, int width, float percentMines)
        {
            boardLength = length;
            boardWidth = width;
            numMines = (int)((length * width) * percentMines); //Calculates what percentage of the board is mines

            //Initialize 2D array
            minefield = new DigSpot[length][]; //Initializes rows
            for (int i = 0; i < length; i++)
                minefield[i] = new DigSpot[width]; //Initializes cols
            
        }
        public int getLength() { return boardLength; }
        public int getWidth() { return boardWidth; }
        public int getNumMines() { return numMines; }
    }
}
