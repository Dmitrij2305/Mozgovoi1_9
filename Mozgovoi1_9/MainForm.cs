using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mozgovoi1_9
{
    public partial class MainForm : Form
    {
        private const int cellWidth = 8;
        private const int cellHeight = 8;

        private const int columnsCount = 30;
        private const int rowsCount = 30;

        private const int initialCellsCount = 50;

        private Graphics canvas;
        private Pen pen = new Pen(Color.Black);
        private SolidBrush drawerBrush = new SolidBrush(Color.Purple);
        private SolidBrush eraserBrush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
        
        private Timer timer;
        private CellAutomata2D automata;

        public MainForm()
        {
            InitializeComponent();
            canvas = lifePanel.CreateGraphics();

            automata = new CellAutomata2D(columnsCount, rowsCount, LifeEvolutionStrategy.Instance);

            timer = new Timer();
            timer.Interval = 150;
            timer.Tick += timer_Tick; 
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            automata.DoStep();
            canvas.Clear(Color.FromKnownColor(KnownColor.Window));
            drawGrid(columnsCount, rowsCount);
            redrawField();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
                startButton.Text = "Пуск";
            }
            else
            {
                timer.Enabled = true;
                startButton.Text = "Стоп";
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            drawGrid(columnsCount, rowsCount);
            automata.Initialize(initialCellsCount);
            redrawField();
        }

        private void drawGrid(int colCount, int rowCount)
        {
            for (int columnIndex = 0; columnIndex <= colCount; columnIndex++)
                canvas.DrawLine(pen, cellWidth * columnIndex, 0, cellWidth * columnIndex, rowsCount * cellHeight);
            for (int rowIndex = 0; rowIndex <= rowCount; rowIndex++)
                canvas.DrawLine(pen, 0, cellHeight * rowIndex, columnsCount * cellWidth, cellHeight * rowIndex);
        }

        private void lifePanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            drawCiliate(e.X / cellWidth + 1, e.Y / cellHeight + 1);
        }

        private void redrawField()
        {
            for (int rowIndex = 1; rowIndex < automata.Field.RowsCount + 1; rowIndex++)
                for (int colIndex = 1; colIndex < automata.Field.ColumnsCount + 1; colIndex++)       
                    if (automata.Field.Get(rowIndex, colIndex) > 0)
                        drawCiliate(colIndex, rowIndex);
        }

        private void drawCiliate(int colIndex, int rowIndex)
        {
            canvas.FillRectangle(drawerBrush, (colIndex - 1) * cellWidth, (rowIndex - 1) * cellHeight, cellWidth, cellHeight);
        }
    }
}
