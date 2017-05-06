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
        private const int cellWidth = 20;
        private const int cellHeight = 20;
        private const int cellcolCount = 10;
        private const int cellrowCount = 10;

        private Graphics canvas;
        private Pen pen;
        private SolidBrush solidBrush;
        private SolidBrush eraser;
        
        private Timer timer;
        private CellAutomata2D automata;

        public MainForm()
        {
            InitializeComponent();
            canvas = lifePanel.CreateGraphics();
            solidBrush = new SolidBrush(Color.Purple);
            eraser = new SolidBrush(lifePanel.BackColor);
            pen = new Pen(Color.Black);

            automata = new CellAutomata2D(cellcolCount, cellrowCount, LifeEvolutionStrategy.Instance);

            timer = new Timer();
            timer.Interval = 150;
            timer.Tick += timer_Tick; 
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            automata.DoStep();
            redrawField();
        }

        private void redrawField()
        {
            throw new NotImplementedException();
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

        private void drawCiliate(int colIndex, int rowIndex)
        {
            canvas.FillRectangle(solidBrush, (colIndex - 1) * cellWidth, (rowIndex - 1) * cellHeight, cellWidth, cellHeight);
        }

        private void DrawGrid(int colCount, int rowCount)
        {
            for (int columnIndex = 1; columnIndex <= colCount; columnIndex++)
                canvas.DrawLine(pen, cellWidth * columnIndex, 0, cellWidth * columnIndex, cellrowCount * cellHeight);
            for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
                canvas.DrawLine(pen, 0, cellHeight * rowIndex, cellcolCount * cellWidth, cellHeight * rowIndex);
        }

        private void eraserCiliate(int colIndex, int rowIndex)
        {
            canvas.FillRectangle(eraser, (colIndex - 1) * cellWidth, 2 * (rowIndex - 1) * cellHeight, cellWidth, cellHeight);
            canvas.DrawRectangle(pen, (colIndex - 1) * cellWidth, 2 * (rowIndex - 1) * cellHeight, cellWidth, cellHeight);
        }

        private void DoStep()
        {
            for (int colIndex = 1; colIndex <= cellcolCount; colIndex++)
                for (int rowIndex = 1; rowIndex <= cellrowCount; rowIndex++)
                    automata.DoStep();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DrawGrid(cellcolCount, cellrowCount);
        }

        private void lifePanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            drawCiliate(e.X / cellWidth + 1, e.Y / cellHeight + 1);
        }
    }
}
