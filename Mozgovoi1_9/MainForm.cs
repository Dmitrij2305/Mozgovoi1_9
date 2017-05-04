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
        private const int Width = 30;
        private const int Height = 25;

        private Graphics canvas;
        private Pen pen;
        private SolidBrush solidBrush;
        private SolidBrush eraser;
        
        private Timer timer;
        private bool[,] field, newField, changes;
        private int rx, ry;
        byte neighbors;
        IEvolutionStrategy instance;

        public MainForm()
        {
            InitializeComponent();
            canvas = lifePanel.CreateGraphics();
            solidBrush = new SolidBrush(Color.Purple);
            eraser = new SolidBrush(lifePanel.BackColor);
            pen = new Pen(Color.Black);

            rx = lifePanel.Width / (2 * Width);
            ry = lifePanel.Height / (2 * Height);
            field = new bool[Width + 2, Height + 2];
            newField = new bool[Width + 2, Height + 2];
            changes = new bool[Width + 2, Height + 2];
            timer = new Timer();
            timer.Interval = 150;
            timer.Tick += delegate(object sender, EventArgs e) { DoStepNew(); };

            //CellAutomata2D automata = new CellAutomata2D(LifeEvolutionStrategy.Instance);
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

        private void drawCiliate(int indexColumn, int indexRow)
        {
            canvas.FillRectangle(solidBrush, 2 * (indexColumn - 1) * rx, 2 * (indexRow - 1) * ry, 2 * rx, 2 * ry);
        }

        private void DrawGrid(int columnCount, int rowCount)
        {
            for (int columnIndex = 1; columnIndex <= columnCount; columnIndex++)
                canvas.DrawLine(pen, 2 * rx * columnIndex, 0, 2 * rx * columnIndex, 2 * Height * ry);
            for (int rowIndex = 1; rowIndex <= rowCount; rowIndex++)
                canvas.DrawLine(pen, 0, 2 * ry * rowIndex, 2 * Width * rx, 2 * ry * rowIndex);
        }

        private void eraserCiliate(int indexColumn, int indexRow)
        {
            canvas.FillRectangle(eraser, 2 * (indexColumn - 1) * rx, 2 * (indexRow - 1) * ry, 2 * rx, 2 * ry);
            canvas.DrawRectangle(pen, 2 * (indexColumn - 1) * rx, 2 * (indexRow - 1) * ry, 2 * rx, 2 * ry);
        }

        private void DoStepNew()
        {
            for (int colIndex = 1; colIndex <= Width; colIndex++)
            {
                for (int rowIndex = 1; rowIndex <= Height; rowIndex++)
                {
                    neighbors = 0;

                    if (field[rowIndex + 1, colIndex + 1])
                        neighbors += (byte)Neighbor.SE;
                    if (field[rowIndex + 1, colIndex])
                        neighbors += (byte)Neighbor.S;
                    if (field[rowIndex + 1, colIndex - 1])
                        neighbors += (byte)Neighbor.SW;
                    if (field[rowIndex, colIndex + 1])
                        neighbors += (byte)Neighbor.E;
                    if (field[rowIndex, colIndex - 1])
                        neighbors += (byte)Neighbor.W;
                    if (field[rowIndex - 1, colIndex + 1])
                        neighbors += (byte)Neighbor.NE;
                    if (field[rowIndex - 1, colIndex])
                        neighbors += (byte)Neighbor.N;
                    if (field[rowIndex - 1, colIndex - 1])
                        neighbors += (byte)Neighbor.NW;

                    if (field[rowIndex, colIndex])
                        newField[rowIndex, colIndex] = instance.HasSurvived(neighbors);
                    else
                        newField[rowIndex, colIndex] = instance.HasBorn(neighbors);
                    }
                }

            for (int colIndex = 1; colIndex <= Width; colIndex++)
            {
                for (int rowIndex = 1; rowIndex <= Height; rowIndex++)
                {
                    if (newField[rowIndex, colIndex])
                    {
                        field[colIndex, rowIndex] = true;
                        drawCiliate(colIndex, rowIndex);
                    }
                    else
                    {
                        field[colIndex, rowIndex] = true;
                        eraserCiliate(colIndex, rowIndex);
                    }
                }
            }
        }

        private void DoStep()
        {
            for (int indexColumn = 1; indexColumn <= Width; indexColumn++)
            {
                for (int indexRow = 1; indexRow <= Height; indexRow++)
                {
                    neighbors = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (field[indexColumn + i, indexRow + j])
                                neighbors++;
                        }
                    }

                    if (field[indexColumn, indexRow])
                        neighbors--;

                    if ((field[indexColumn, indexRow] == false) && (neighbors == 3) || 
                        (field[indexColumn, indexRow] == true) && ((neighbors < 2) || (neighbors > 3)))
                        changes[indexColumn, indexRow] = true;
                }
            }
            for (int indexColumn = 1; indexColumn <= Width; indexColumn++)
            {
                for (int indexRow = 1; indexRow <= Height; indexRow++)
                {
                    if (changes[indexColumn, indexRow])
                    {
                        field[indexColumn, indexRow] = !field[indexColumn, indexRow];
                        changes[indexColumn, indexRow] = false;
                        if (field[indexColumn, indexRow])
                            drawCiliate(indexColumn, indexRow);
                        else
                            eraserCiliate(indexColumn, indexRow);
                    }
                }
            }

            //canvas.Clear(lifePanel.BackColor);
            //DrawGrid(Width, Height);

            //for (int columnIndex = 1; columnIndex <= Width; columnIndex++)
            //    for (int rowIndex = 1; rowIndex <= Height; rowIndex++)
            //        if (field[columnIndex, rowIndex])
            //            drawCiliate(columnIndex, rowIndex);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DrawGrid(Width, Height);
        }

        private void lifePanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            drawCiliate(e.X / (2 * rx) + 1, e.Y / (2 * ry) + 1);
            field[e.X / (2 * rx) + 1, e.Y / (2 * ry) + 1] = true;
        }
    }
}
