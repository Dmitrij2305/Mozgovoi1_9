using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozgovoi1_9
{
    class CellAutomata2D
    {
        private static Random rnd = new Random();

        private IEvolutionStrategy strategy;

        private CellAutomataField field;

        public CellAutomata2D(int width, int height, IEvolutionStrategy strategy)
        {
            this.strategy = strategy;
            this.field = new CellAutomataField(height, width);
        }

        public CellAutomataField Field
        {
            get { return field; }
        }

        public void Initialize(int cellsCount)
        {
            for (int index = 0; index < cellsCount; index++)
            {
                int rowIndex = rnd.Next(1, field.RowsCount + 1);
                int columnIndex = rnd.Next(1, field.ColumnsCount + 1);

                field.Spawn(rowIndex, columnIndex);
            }
        }

        public void DoStep()
        {
            CellAutomataField newField = new CellAutomataField(field.RowsCount, field.ColumnsCount);

            for (int rowIndex = 1; rowIndex < field.RowsCount - 1; rowIndex++)
                for (int colIndex = 1; colIndex < field.ColumnsCount - 1; colIndex++)
                {
                    if (field.Get(rowIndex, colIndex) == 1 && strategy.HasSurvived(getNeighborsPattern(rowIndex, colIndex)))
                        newField.Spawn(rowIndex, colIndex);
                    else if (field.Get(rowIndex, colIndex) == 0 && strategy.HasBorn(getNeighborsPattern(rowIndex, colIndex)))
                        newField.Spawn(rowIndex, colIndex);
                }

            field = newField;
        }

        private byte getNeighborsPattern(int rowIndex, int colIndex)
        {
            byte pattern = 0;

            if (field.GetNeighbor(Neighbor.SE, rowIndex, colIndex) > 0)
                pattern += (byte)Neighbor.SE;
            if (field.GetNeighbor(Neighbor.S, rowIndex, colIndex) > 0)
                pattern += (byte)Neighbor.S;
            if (field.GetNeighbor(Neighbor.SW, rowIndex, colIndex) > 0)
                pattern += (byte)Neighbor.SW;
            if (field.GetNeighbor(Neighbor.E, rowIndex, colIndex) > 0)
                pattern += (byte)Neighbor.E;
            if (field.GetNeighbor(Neighbor.W, rowIndex, colIndex) > 0)
                pattern += (byte)Neighbor.W;
            if (field.GetNeighbor(Neighbor.NE, rowIndex, colIndex) > 0)
                pattern += (byte)Neighbor.NE;
            if (field.GetNeighbor(Neighbor.N, rowIndex, colIndex) > 0)
                pattern += (byte)Neighbor.N;
            if (field.GetNeighbor(Neighbor.NW, rowIndex, colIndex) > 0)
                pattern += (byte)Neighbor.NW;

            return pattern;
        }
    }
}
