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
            this.field = new int[height, width];
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

            for (int rowIndex = 0; rowIndex < field.GetLength(0); rowIndex++)
                for (int colIndex = 0; colIndex < field.GetLength(1); colIndex++)
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
            throw new NotImplementedException();
        }
    }
}
