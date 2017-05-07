using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mozgovoi1_9
{
    class CellAutomataField
    {
        private int rowsCount;
        private int columnsCount;

        private int[,] field;

        public CellAutomataField(int rowsCount, int columnsCount)
        {
            this.rowsCount = rowsCount;
            this.columnsCount = columnsCount;

            this.field = new int[rowsCount + 2, columnsCount + 2];
        }

        public int RowsCount
        {
            get { return rowsCount; }
        }

        public int ColumnsCount
        {
            get { return columnsCount; }
        }

        public int Get(int row, int column)
        {
            return field[row, column];
        }

        public int GetNeighbor(Neighbor neighbor, int row, int column)
        {
            if ((neighbor & (Neighbor.NW | Neighbor.N | Neighbor.NE)) > 0)
                row -= 1;
            if ((neighbor & (Neighbor.SW | Neighbor.S | Neighbor.SE)) > 0)
                row += 1;

            if ((neighbor & (Neighbor.NW | Neighbor.W | Neighbor.SW)) > 0)
                column -= 1;
            if ((neighbor & (Neighbor.NE | Neighbor.E | Neighbor.SE)) > 0)
                column += 1;
            
            return field[row, column];
        }

        public void Spawn(int row, int column, int value = 1)
        {
            if (row < 1 || row > rowsCount)
                throw new ArgumentOutOfRangeException("row");
            
            if (column < 1 || column > columnsCount)
                throw new ArgumentOutOfRangeException("column");

            field[row, column] = value;
        }

        public void Kill(int row, int column)
        {
            if (row < 1 || row > rowsCount)
                throw new ArgumentOutOfRangeException("row");

            if (column < 1 || column > columnsCount)
                throw new ArgumentOutOfRangeException("column");

            field[row, column] = 0;
        }
    }
}
