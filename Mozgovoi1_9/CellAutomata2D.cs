using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozgovoi1_9
{
    class CellAutomata2D
    {
        private IEvolutionStrategy strategy;

        private int[,] field;

        public CellAutomata2D(int width, int height, IEvolutionStrategy strategy)
        {
            this.strategy = strategy;
            this.field = new int[height + 2, width + 2];
        }

        public void Spawn(int X, int Y)
        {

        }

        public void Kill(int X, int Y)
        {

        }

        public void DoStep()
        {
            int[,] newField = new int[field.GetLength(0), field.GetLength(1)];

            for (int rowIndex = 1; rowIndex < field.GetLength(0) - 1; rowIndex++)
                for (int colIndex = 1; colIndex < field.GetLength(1) - 1; colIndex++)
                {
                    if (field[rowIndex, colIndex] == 1 && strategy.HasSurvived(getNeighborsPattern(rowIndex, colIndex)))
                        newField[rowIndex, colIndex] = 1;
                    else if (field[rowIndex, colIndex] == 0 && strategy.HasBorn(getNeighborsPattern(rowIndex, colIndex)))
                        newField[rowIndex, colIndex] = 1;
                }

            field = newField;
        }

        private byte getNeighborsPattern(int rowIndex, int colIndex)
        {
            byte pattern = 0;

            if (field[rowIndex + 1, colIndex + 1] == 1)
                pattern += (byte)Neighbor.SE;
            if (field[rowIndex + 1, colIndex] == 1)
                pattern += (byte)Neighbor.S;
            if (field[rowIndex + 1, colIndex - 1] == 1)
                pattern += (byte)Neighbor.SW;
            if (field[rowIndex, colIndex + 1] == 1)
                pattern += (byte)Neighbor.E;
            if (field[rowIndex, colIndex - 1] == 1)
                pattern += (byte)Neighbor.W;
            if (field[rowIndex - 1, colIndex + 1] == 1)
                pattern += (byte)Neighbor.NE;
            if (field[rowIndex - 1, colIndex] == 1)
                pattern += (byte)Neighbor.N;
            if (field[rowIndex - 1, colIndex - 1] == 1)
                pattern += (byte)Neighbor.NW;

            return pattern;
        }
    }
}
